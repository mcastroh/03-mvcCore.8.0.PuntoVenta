﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace WebPuntoVenta.Data.Models;

public partial class Productos
{
    public int Id { get; set; }

    public string Producto { get; set; }

    public int IdCategoria { get; set; }

    public int IdProveedor { get; set; }

    public int IdOcasion { get; set; }

    public virtual Categorias IdCategoriaNavigation { get; set; }

    public virtual Proveedores IdProveedorNavigation { get; set; }

    public virtual ICollection<ProductoOcasiones> ProductoOcasiones { get; set; } = new List<ProductoOcasiones>();
}