using System;
using System.Collections.Generic;

namespace Rei.Infrastructure;

public partial class MaterialsLocation
{
    public int MaterialLocationId { get; set; }

    public int MaterialId { get; set; }

    public int WorldId { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Material World { get; set; } = null!;
}
