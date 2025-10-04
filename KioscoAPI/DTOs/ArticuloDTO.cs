namespace KioscoAPI.DTOs
{
    public class ArticuloDTO
    {
        public int IdArticulo { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Estado { get; set; }
        public CategoriaDTO categoria { get; set; }
    }
}
