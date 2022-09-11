namespace Lambda.GeradorPDF.Model
{
    public class FilePDF
    {
        public FilePDF(byte[] conteudo, string tipo)
        {
            Conteudo = conteudo;
            Nome = Guid.NewGuid();
            Tipo = tipo;
        }
        public byte[] Conteudo { get; set; }
        public Guid Nome { get; set; }
        public string Tipo { get; set; }
    }
}
