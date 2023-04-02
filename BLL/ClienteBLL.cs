using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ClienteBLL {
  private Contexto _contexto;

  public ClienteBLL(Contexto contexto) {
    _contexto = contexto;
  }

  public bool Existe(int clienteId) {
    return _contexto.Cliente.Any(o => o.ClienteId == clienteId);
  }

  private bool Insertar(Cliente cliente) {
    _contexto.Cliente.Add(cliente);
    return _contexto.SaveChanges() > 0;
  }

  private bool Modificar(Cliente cliente) {
    var clienteExistente = _contexto.Cliente.Find(cliente.ClienteId);
    if (clienteExistente == null) {
        return false;
    }

    _contexto.Entry(clienteExistente).CurrentValues.SetValues(cliente);
    return _contexto.SaveChanges() > 0;
}


  public bool Guardar(Cliente cliente) {
    if (cliente == null || cliente.ClienteId <= 0) {
      return false; // Libro no válido, no se puede guardar
    }

    if (!Existe(cliente.ClienteId)) {
      return this.Insertar(cliente);
    } else {
      return this.Modificar(cliente);
    }
  }

  public bool Eliminar(Cliente cliente) {
    if (Existe(cliente.ClienteId)) {
      var clienteEliminacion = _contexto.Cliente.Find(cliente.ClienteId);
      _contexto.Entry(clienteEliminacion).State = EntityState.Deleted;
      return _contexto.SaveChanges() > 0;
    } else {
      return false;
    }
  }

  public Cliente ? Buscar(int clienteId) {
    return _contexto.Cliente
      .Where(o => o.ClienteId == clienteId)
      .AsNoTracking()
      .SingleOrDefault();
  }

  public List < Cliente > GetList(Expression < Func < Cliente, bool >> criterio) {
    return _contexto.Cliente.AsNoTracking().Where(criterio).ToList();
  }

}