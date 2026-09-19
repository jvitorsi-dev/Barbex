Namespace Modelos
    ''' <summary>
    ''' Interface implementada por toda entidade que possui identificador único.
    ''' Permite que o repositório genérico trabalhe com qualquer entidade.
    ''' </summary>
    Public Interface IIdentificavel
        ReadOnly Property Id As Integer
    End Interface
End Namespace
