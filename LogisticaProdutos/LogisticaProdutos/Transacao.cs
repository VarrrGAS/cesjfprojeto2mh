//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogisticaProdutos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transacao
    {
        public int Id { get; set; }
        public int IdBebida { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoTransacao { get; set; }
        public int Qtd { get; set; }
    
        public virtual Bebida Bebida { get; set; }
        public virtual TipoTransacao TipoTransacao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}