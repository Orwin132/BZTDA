namespace NardSmena.Models
{
    public class CombinedViewModelSprOperation
    {
        public IEnumerable<TARIF> TarifList { get; set; }
        public IEnumerable<OtpVred> OtpVredList { get; set; }
        public IEnumerable<Sproper> SprOperList { get; set; }
        public IEnumerable<SprDet> SprDetList { get; set; }
    }
}
