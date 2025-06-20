using CareerLaunchpad.Models;

public class Service
{
    public int ServiceId { get; set; }

    // نهيّئ السلسلة لتكون non-nullable
    public string? ServiceName { get; set; } = string.Empty;

    // وصف الخدمة قد يكون فارغاً
    public string? Servicedescription { get; set; }

    // قائمة المشاريع المرتبطة بهذه الخدمة
    public List<Project> Projects { get; set; } = new();

    // المفتاح الأجنبي لبورتفوليو
    public int PortfolioId { get; set; }

    // الخاصيّة التنقلية—نهيّئها كي لا تكون null
    public Portfolio Portfolio { get; set; } = null!;
}
