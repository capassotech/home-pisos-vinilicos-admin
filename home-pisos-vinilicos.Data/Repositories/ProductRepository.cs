using System;

namespace home_pisos_vinilicos_admin.Data
{
    //public class ProductRepository : IProductRepository
    //{
    //    private readonly FirestoreDb _db;

    //    public ProductRepository()
    //    {
    //        _db = FirestoreDb.Create("your-project-id");
    //    }

    //    public async Task AddProductAsync(Product product)
    //    {
    //        CollectionReference productsRef = _db.Collection("products");
    //        await productsRef.AddAsync(product);
    //    }

    //    public async Task<List<Product>> GetProductsAsync()
    //    {
    //        QuerySnapshot snapshot = await _db.Collection("products").GetSnapshotAsync();
    //        return snapshot.Documents.Select(doc => doc.ConvertTo<Product>()).ToList();
    //    }
    //}
}
