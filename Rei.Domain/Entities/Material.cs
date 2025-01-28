using System;
using System.Collections.Generic;

namespace Rei.Infrastructure;

public partial class Material
{
    public int MaterialId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<MaterialsLocation> MaterialsLocationMaterials { get; set; } = new List<MaterialsLocation>();

    public virtual ICollection<MaterialsLocation> MaterialsLocationWorlds { get; set; } = new List<MaterialsLocation>();
}
