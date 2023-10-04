using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models.Repo
{
    interface IProductRepo
    {
        //列出清單
        IQueryable<Product> ListAllProduct();

        //列出某個紀錄
        Product GetProductById(int id);

        //搜尋
        Product GetProductByName(string name);

        //新增
        bool AddProduct(Product product);
        //更新
        bool UpdateProduct(Product product);

        //刪除
        bool DeleteProduct(Product product);
    }
}
