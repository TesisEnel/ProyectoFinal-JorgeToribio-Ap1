using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class CarroBLL {
  private Contexto _contexto;

  public CarroBLL(Contexto contexto) {
    _contexto = contexto;
  }

  public bool Existe(int CarroId) {
    return _contexto.Carro.Any(o => o.CarroId == CarroId);
  }

  private bool Insertar(Carro carro) {
    _contexto.Carro.Add(carro);
    return _contexto.SaveChanges() > 0;
  }

  private bool Modificar(Carro carro) {
    var carroExistente = _contexto.Carro.Find(carro.CarroId);
    if (carroExistente == null) {
        return false;
    }

    _contexto.Entry(carroExistente).CurrentValues.SetValues(carro);
    return _contexto.SaveChanges() > 0;
}


  public bool Guardar(Carro carro) {
    if (carro == null || carro.CarroId <= 0) {
      return false; // Libro no válido, no se puede guardar
    }

    if (!Existe(carro.CarroId)) {
      return this.Insertar(carro);
    } else {
      return this.Modificar(carro);
    }
  }

  public bool Eliminar(Carro carro) {
    if (Existe(carro.CarroId)) {
      var CarroEliminar = _contexto.Carro.Find(carro.CarroId);
      _contexto.Entry(CarroEliminar).State = EntityState.Deleted;
      return _contexto.SaveChanges() > 0;
    } else {
      return false;
    }
  }

  public Carro ? Buscar(int carroId) {
    return _contexto.Carro
      .Where(o => o.CarroId == carroId)
      .AsNoTracking()
      .SingleOrDefault();
  }

  public List < Carro > GetList(Expression < Func < Carro, bool >> criterio) {
    return _contexto.Carro.AsNoTracking().Where(criterio).ToList();
  }

}