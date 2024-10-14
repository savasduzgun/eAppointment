using Ardalis.SmartEnum;

namespace eAppointmentServer.Domain.Enums
{
    public sealed class DepertmentEnum : SmartEnum<DepertmentEnum>
    {
        public static readonly DepertmentEnum Acil = new("Acil", 1);
        public static readonly DepertmentEnum Radyoloji = new("Radyoloji", 2);
        public static readonly DepertmentEnum Kardioloji = new("Kardioloji", 3);
        public static readonly DepertmentEnum Dermatoloji = new("Dermatoloji", 4);
        public static readonly DepertmentEnum Endokrinoloji = new("Endokrinoloji", 5);
        public static readonly DepertmentEnum Gastroenteroloji = new("Gastroenteroloji", 6);
        public static readonly DepertmentEnum GenelCerrahi = new("Genel Cerrahi", 7);
        public static readonly DepertmentEnum JinekolojiveObstetrik = new("Jinekoloji ve Obstetrik", 8);
        public static readonly DepertmentEnum Hematoloji = new("Hematoloji", 9);
        public static readonly DepertmentEnum EnfeksiyonHastalıklari = new("Enfeksiyon Hastalıkları", 10);
        public static readonly DepertmentEnum Nefroloji = new("Nefroloji", 11);
        public static readonly DepertmentEnum Nöroloji = new("Nöroloji", 12);
        public static readonly DepertmentEnum Ortopedi = new("Ortopedi", 13);
        public static readonly DepertmentEnum Pediatri = new("Pediatri", 14);
        public static readonly DepertmentEnum Psikiyatri = new("Psikiyatri", 15);
        public static readonly DepertmentEnum Pulmonoloji = new("Pulmonoloji", 16);
        public DepertmentEnum(string name, int value) : base(name, value)
        {
        }
    }
}
