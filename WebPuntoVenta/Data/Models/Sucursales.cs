﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
namespace WebPuntoVenta.Data.Models;

public partial class Sucursales
{
    public int Id { get; set; }

    public string Sucursal { get; set; }

    public int IdDireccion { get; set; }

    public virtual Direcciones IdDireccionNavigation { get; set; }
}