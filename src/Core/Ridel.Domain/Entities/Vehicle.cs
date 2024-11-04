using Ridel.Domain.Common;

namespace Ridel.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
 
        public string DriverId { get; set; } // Aracı ekleyen sürücünün ID'si
        public Driver Driver { get; set; } // İlişkili sürücü

        // Araç bilgileri
        public string VehicleName { get; set; } // Araç adı
        public string Brand { get; set; } // Marka
        public string Model { get; set; } // Model
        public int Year { get; set; } // Araç yılı
        public string ExteriorColor { get; set; } // Araç dış renk
        public string InteriorColor { get; set; } // Araç iç renk
        public string PlateNumber { get; set; } // Araç plaka
        public bool IsCommercial { get; set; } // Ticari veya bireysel araç mı?
        public string TcpNumber { get; set; } // Ticari Araç TCP No (varsa)
        public bool HasAirportPermit { get; set; } // Havaalanı izni var mı?
        public int PassengerCapacity { get; set; } // Araç kaç kişilik?
        public bool HasChildSeat { get; set; } // Çocuk koltuğu var mı?
        public int ChildSeatCount { get; set; } // Çocuk koltuğu sayısı (varsa)

        // Araç tipi ilişkisi (Economy, Business, SUV, vb.)
        public Guid VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } // Araç türü

        // Araç için seçilen ek özellikler
        public ICollection<VehicleFeature> Features { get; set; }

        // Araç fotoğrafları
        public ICollection<VehiclePhoto> Photos { get; set; } // Araç görselleri (birden fazla olabilir)
 
    }

    // Araç fotoğraflarını temsil eden ayrı bir sınıf
    public class VehiclePhoto
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string PhotoUrl { get; set; } // AWS S3 gibi bir depolama alanında saklanacak fotoğraf URL'si
    }
}
