using System;
using System.Collections.Generic;

namespace Rei.Infrastructure;

public partial class World
{
    public int WorldId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
