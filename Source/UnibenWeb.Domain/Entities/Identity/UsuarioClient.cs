namespace UnibenWeb.Domain.Entities.Identity
{
    //[Table("AspNetClients")]
    public class UsuarioClient
    {
        //[Key]
        public int Id { get; set; }
        public string UserKey { get; set; }
    }
}