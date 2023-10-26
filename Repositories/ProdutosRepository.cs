using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class ProdutosRepository
    {

        private readonly AppDbContext _context;

        public ProdutosRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> Get()
        {
            var produtos = _context.Produtos.AsNoTracking();
            if (produtos is null)
            {
                throw new Exception("Produtos não encontrados...");
            }
            return produtos;
        }
        public Produto GetById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }
            return produto;
        }
        public Produto AddProduto(Produto produto)
        {
            if (produto is null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }
        public Produto PutProdutoById(int id, Produto produto)
        {
            if (produto is null)
            {
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }

        public void DeleteProduto(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser excluido.");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

    }
}

