using MyFirstProject.Models;

namespace MyFirstProject.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
}