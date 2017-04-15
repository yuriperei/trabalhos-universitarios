using System.ComponentModel;

namespace MustDo.Domain.ENUM
{
	public enum SituacaoTarefaEnum
	{
		[Description("Em progresso")]
		Progresso,

		[Description("Finalizada")]
		Finalizada,

		[Description("Atrasada")]
		Atrasada,

		[Description("Cancelada")]
		Cancelada
	};
}
