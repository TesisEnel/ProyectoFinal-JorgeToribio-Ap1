using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PagoBLL
{
    private Contexto _contexto;

    public PagoBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int pagoId)
    {
        return _contexto.Pago.Any(o => o.PagoId == pagoId);
    }

    private bool Insertar(Pago pago)
    {
        _contexto.Pago.Add(pago);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Pago pago)
    {
        var pagoExistente = _contexto.Pago.Find(pago.PagoId);
        if (pagoExistente == null)
        {
            return false;
        }

        _contexto.Entry(pagoExistente).CurrentValues.SetValues(pago);
        return _contexto.SaveChanges() > 0;
    }


    public bool Guardar(Pago pago)
    {
        if (!Existe(pago.PagoId))
        {
            return this.Insertar(pago);
        }
        else
        {
            return this.Modificar(pago);
        }
    }

    public bool Eliminar(Pago pago)
    {
        if (Existe(pago.PagoId))
        {
            var PagoEliminacion = _contexto.Cliente.Find(pago.PagoId);
            _contexto.Entry(PagoEliminacion).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        else
        {
            return false;
        }
    }

    public Pago? Buscar(int pagoId)
    {
        return _contexto.Pago
          .Where(o => o.PagoId == pagoId)
          .AsNoTracking()
          .SingleOrDefault();
    }

    public List<Pago> GetList(Expression<Func<Pago, bool>> criterio)
    {
        return _contexto.Pago.AsNoTracking().Where(criterio).ToList();
    }

}