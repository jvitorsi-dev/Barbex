Namespace Excecoes
    ''' <summary>
    ''' Lançada quando se tenta agendar um horário que conflita com outro
    ''' agendamento do MESMO profissional (intervalos sobrepostos).
    ''' </summary>
    Public Class HorarioOcupadoException
        Inherits BarbexException

        Public ReadOnly Property NomeProfissional As String
        Public ReadOnly Property InicioConflito As DateTime
        Public ReadOnly Property FimConflito As DateTime

        Public Sub New(nomeProfissional As String, inicioConflito As DateTime, fimConflito As DateTime)
            MyBase.New($"O profissional {nomeProfissional} já possui um agendamento das {inicioConflito:HH:mm} às {fimConflito:HH:mm} neste dia.")
            Me.NomeProfissional = nomeProfissional
            Me.InicioConflito = inicioConflito
            Me.FimConflito = fimConflito
        End Sub

    End Class
End Namespace
