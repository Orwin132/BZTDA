using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using dBASE.NET;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NardSmena.Controllers
{
    public class HomeImportController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeImportController> _logger;

        public HomeImportController(IWebHostEnvironment environment, IConfiguration configuration, ILogger<HomeImportController> logger)
        {
            _environment = environment;
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];

                // Проверка расширения файла
                if (file == null || file.Length == 0 || Path.GetExtension(file.FileName).ToLower() != ".dbf")
                {
                    return Json(new { success = false, message = "Выберите файл с расширением .dbf." });
                }

                // Генерация уникального имени файла
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                var filePath = Path.Combine(_environment.WebRootPath, "AppData", uniqueFileName);

                // Сохранение файла на сервер
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                
                using (var dbfConnection = new SqlConnection(_configuration.GetSection("ConnectionString")["DefaultConnection"]))
                {
                    dbfConnection.Open();
                    using (var dbfCommand = new SqlCommand($"SELECT * FROM {Path.GetFileNameWithoutExtension(filePath)}", dbfConnection))
                    using (var dbfAdapter = new SqlDataAdapter(dbfCommand))
                    {
                        var dbfDataTable = new DataTable();
                        dbfAdapter.Fill(dbfDataTable);

                        foreach (DataRow row in dbfDataTable.Rows)
                        {
                            await InsertDataIntoDatabaseAsync(Convert.ToInt32(row["TAB"]), row["FAB"].ToString());
                        }
                    }
                }

                // Отправляем успешное сообщение
                return Json(new { success = true, message = "Импорт данных файла произошел успешно" });
            }
            catch (Exception ex)
            {
                // Логгируем ошибку
                return Json(new { success = false, message = "Произошла ошибка при загрузке данных файла: " + ex.Message });
            }
        }

        private async Task InsertDataIntoDatabaseAsync(int tabNomerColumn, string fioColumn)
        {
            string connectionString = _configuration.GetSection("ConnectionString")["DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string insertQuery = "INSERT INTO SPRRAB (FIO, TabNomer) VALUES (@tabNomer, @fio)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.Add("@tabNomer", SqlDbType.Int).Value = tabNomerColumn;
                    command.Parameters.Add("@fio", SqlDbType.VarChar).Value = fioColumn;
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
