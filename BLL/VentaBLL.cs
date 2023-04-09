using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class VentaBLL
{
    private Contexto _Contexto;

    public VentaBLL(Contexto contexto)
    {
        _Contexto = contexto;
    }

    public bool Existe(int ventaId)
    {
        return _Contexto.Venta.Any(o => o.VentaId == ventaId);
    }

    private bool Insertar(Venta venta)
    {
        _Contexto.Venta.Add(venta);
        return _Contexto.SaveChanges() > 0;
    }

    private bool Modificar(Venta venta)
    {
        var VentaExistencia = _Contexto.Venta.Find(venta.VentaId);
        if (VentaExistencia == null)
        {
            return false;
        }

        _Contexto.Entry(VentaExistencia).CurrentValues.SetValues(venta);
        return _Contexto.SaveChanges() > 0;
    }


    public bool Guardar(Venta venta)
    {
        if (!Existe(venta.VentaId))
        {
            return this.Insertar(venta);
        }
        else
        {
            return this.Modificar(venta);
        }
    }

    public bool Eliminar(int ventaId)
    {
        var venta = _Contexto.Venta.Include(p => p.VentaDetalle).FirstOrDefault(p => p.VentaId == ventaId);

        if (venta != null)
        {
            foreach (var detalle in venta.VentaDetalle)
            {
                var carro = _Contexto.Carro.Find(detalle.VentaId);
                if (carro == null)
                {
                    continue;
                }
            }

            _Contexto.RemoveRange(venta.VentaDetalle);
            _Contexto.Entry(venta).State = EntityState.Deleted;

            int filasAfectadas = _Contexto.SaveChanges();
            return filasAfectadas > 0;
        }
        else
        {
            return false;
        }
    }

    public Venta? Buscar(int ventaId)
    {
        return _Contexto.Venta.Include(o => o.VentaDetalle).Where(o => o.VentaId == ventaId).SingleOrDefault();
    }

    public List<Venta> GetList(Expression<Func<Venta, bool>> criterio)
    {
        return _Contexto.Venta.AsNoTracking().Where(criterio).ToList();
    }

}