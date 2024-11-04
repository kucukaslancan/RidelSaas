namespace Ridel.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } // Tüm entity'ler için benzersiz Id
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Oluşturulma tarihi
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow; // Güncellenme tarihi (opsiyonel)
        public bool IsDeleted { get; set; }
    }
}
