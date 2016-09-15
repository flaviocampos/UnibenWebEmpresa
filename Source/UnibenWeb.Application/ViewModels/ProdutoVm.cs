using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnibenWeb.Application.ViewModels
{
    public class ProdutoVm
    {
        [Key]
        public int ProdutoId { get; set; }
        public int NumeroRegistro { get; set; }
        public int Sigla { get; set; }
        public int DataRegistro { get; set; }
        public bool AtivoSituacao { get; set; } // ativo ou nao

        public int PessoaId { get; set; }
        public int SegmentoAssistencialId { get; set; }
        public int TipoContratacaoProdutoId { get; set; } // Adesao, Empresarial
        public int AbrangenciaPlanoId { get; set; } // Estadual, nacional...
        public int FatorModeradorId { get; set; } // com ou sem coparticipacao
        public int AcomodacaoTipoId { get; set; } // Apartamento, enfermaria, a definir

        //public virtual ICollection<ProdutoTermo> ProdutoTermos { get; set; } // Coleção de Observações sobre o Produto
        //public virtual ICollection<Observacao> Obs { get; set; } // Coleção de Observações sobre o Produto
    }
}