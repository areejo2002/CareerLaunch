namespace CareerLaunchpad.DTOs
{
    public class ServiceDto
    {
        // اسم الخدمة
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ServiceName { get; set; } = string.Empty;

        // وصف الخدمة (اختياري)
        public string? ServiceDescription { get; set; }
    }
}
