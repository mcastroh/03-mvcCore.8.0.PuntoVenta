﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace WebPuntoVenta.Data.Models;

public partial class Direcciones
{
    public int Id { get; set; }

    public int IdAsentamiento { get; set; }

    public string Calle { get; set; }

    public string Numero { get; set; }

    public virtual CodigosPostales IdAsentamientoNavigation { get; set; }

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();

    public virtual ICollection<Sucursales> Sucursales { get; set; } = new List<Sucursales>();
}