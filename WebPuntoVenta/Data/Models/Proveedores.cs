﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace WebPuntoVenta.Data.Models;

public partial class Proveedores
{
    public int Id { get; set; }

    public string Proveedor { get; set; }

    public int? IdDireccion { get; set; }

    public virtual Direcciones IdDireccionNavigation { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}