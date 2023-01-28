using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeTarefas.Enums;

public enum StatusTarefa
{
    [Description("A Fazer")]
    AFazer = 1,

    [Description("Em Andamento")]
    EmAndamento = 2,

    [Description("Concluido")]
    Concluido = 3,
}
