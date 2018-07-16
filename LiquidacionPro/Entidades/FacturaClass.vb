Public Class FacturaClass

    Private _CODIGO_FACTURA As Integer

    Public Property CODIGO_FACTURA() As Integer
        Get
            Return _CODIGO_FACTURA
        End Get
        Set(ByVal value As Integer)
            _CODIGO_FACTURA = value
        End Set
    End Property

    Private _SERIE_FACTURA As String
    Public Property SERIE_FACTURA() As String
        Get
            Return _SERIE_FACTURA
        End Get
        Set(ByVal value As String)
            _SERIE_FACTURA = value
        End Set
    End Property

    Private _NUMERO_FACTURA As String
    Public Property NUMERO_FACTURA() As String
        Get
            Return _NUMERO_FACTURA
        End Get
        Set(ByVal value As String)
            _NUMERO_FACTURA = value
        End Set
    End Property

    Private _CODIGO_CLIENTE As Integer
    Public Property CODIGO_CLIENTE() As Integer
        Get
            Return _CODIGO_CLIENTE
        End Get
        Set(ByVal value As Integer)
            _CODIGO_CLIENTE = value
        End Set
    End Property

    Private _SUBTOTAL As Double
    Public Property SUBTOTAL() As Double
        Get
            Return _SUBTOTAL
        End Get
        Set(ByVal value As Double)
            _SUBTOTAL = value
        End Set
    End Property

    Private _IGV As Double
    Public Property IGV() As Double
        Get
            Return _IGV
        End Get
        Set(ByVal value As Double)
            _IGV = value
        End Set
    End Property

    Private _TOTAL_FACTURA As Double
    Public Property TOTAL_FACTURA() As Double
        Get
            Return _TOTAL_FACTURA
        End Get
        Set(ByVal value As Double)
            _TOTAL_FACTURA = value
        End Set
    End Property

    Private _CODIGO_MONEDA As Integer
    Public Property CODIGO_MONEDA() As Integer
        Get
            Return _CODIGO_MONEDA
        End Get
        Set(ByVal value As Integer)
            _CODIGO_MONEDA = value
        End Set
    End Property

    Private _CODIGO_ESTADO As Integer
    Public Property CODIGO_ESTADO() As Integer
        Get
            Return _CODIGO_ESTADO
        End Get
        Set(ByVal value As Integer)
            _CODIGO_ESTADO = value
        End Set
    End Property

    Private _FECHA_FACTURA As DateTime
    Public Property FECHA_FACTURA() As DateTime
        Get
            Return _FECHA_FACTURA
        End Get
        Set(ByVal value As DateTime)
            _FECHA_FACTURA = value
        End Set
    End Property

    Private _TIPO_FACTURA As Integer
    Public Property TIPO_FACTURA() As Integer
        Get
            Return _TIPO_FACTURA
        End Get
        Set(ByVal value As Integer)
            _TIPO_FACTURA = value
        End Set
    End Property

    Private _FECHA_PAGO As DateTime
    Public Property FECHA_PAGO() As DateTime
        Get
            Return _FECHA_PAGO
        End Get
        Set(ByVal value As DateTime)
            _FECHA_PAGO = value
        End Set
    End Property

    Private _FECHA_RECEPCION As DateTime
    Public Property FECHA_RECEPCION() As DateTime
        Get
            Return _FECHA_RECEPCION
        End Get
        Set(ByVal value As DateTime)
            _FECHA_RECEPCION = value
        End Set
    End Property

    Private _FECHA_VENCIMIENTO As DateTime
    Public Property FECHA_VENCIMIENTO() As DateTime
        Get
            Return _FECHA_VENCIMIENTO
        End Get
        Set(ByVal value As DateTime)
            _FECHA_VENCIMIENTO = value
        End Set
    End Property

    Private _FECHA_COMPROMISO As DateTime
    Public Property FECHA_COMPROMISO() As DateTime
        Get
            Return _FECHA_COMPROMISO
        End Get
        Set(ByVal value As DateTime)
            _FECHA_COMPROMISO = value
        End Set
    End Property

    Private _PORCENTAJE_DETRACCION As Double
    Public Property PORCENTAJE_DETRACCION() As Double
        Get
            Return _PORCENTAJE_DETRACCION
        End Get
        Set(ByVal value As Double)
            _PORCENTAJE_DETRACCION = value
        End Set
    End Property

    Private _MONTO_DETRACCION As Double
    Public Property MONTO_DETRACCION() As Double
        Get
            Return _MONTO_DETRACCION
        End Get
        Set(ByVal value As Double)
            _MONTO_DETRACCION = value
        End Set
    End Property

    Private _CODIGO_BANCO As Integer
    Public Property CODIGO_BANCO() As Integer
        Get
            Return _CODIGO_BANCO
        End Get
        Set(ByVal value As Integer)
            _CODIGO_BANCO = value
        End Set
    End Property

    Private _ACTUALIZADO As Integer
    Public Property ACTUALIZADO() As Integer
        Get
            Return _ACTUALIZADO
        End Get
        Set(ByVal value As Integer)
            _ACTUALIZADO = value
        End Set
    End Property

    Private _ID_VENTA As String
    Public Property ID_VENTA() As String
        Get
            Return _ID_VENTA
        End Get
        Set(ByVal value As String)
            _ID_VENTA = value
        End Set
    End Property

    Private _SERIE_DOCUMENTO As String
    Public Property SERIE_DOCUMENTO() As String
        Get
            Return _SERIE_DOCUMENTO
        End Get
        Set(ByVal value As String)
            _SERIE_DOCUMENTO = value
        End Set
    End Property

    Private _CORRELATIVO_DOCUMENTO As String
    Public Property CORRELATIVO_DOCUMENTO() As String
        Get
            Return _CORRELATIVO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            _CORRELATIVO_DOCUMENTO = value
        End Set
    End Property

    Private _TIPO_CAMBIO As Double
    Public Property TIPO_CAMBIO() As Double
        Get
            Return _TIPO_CAMBIO
        End Get
        Set(ByVal value As Double)
            _TIPO_CAMBIO = value
        End Set
    End Property

    Private _AFECTA_DETRACCION As Integer
    Public Property AFECTA_DETRACCION() As Integer
        Get
            Return _AFECTA_DETRACCION
        End Get
        Set(ByVal value As Integer)
            _AFECTA_DETRACCION = value
        End Set
    End Property

    Private _ID_MONEDA As Integer
    Public Property ID_MONEDA() As Integer
        Get
            Return _ID_MONEDA
        End Get
        Set(ByVal value As Integer)
            _ID_MONEDA = value
        End Set
    End Property

    Private _NRO_DOCUMENTO As String
    Public Property NRO_DOCUMENTO() As String
        Get
            Return _NRO_DOCUMENTO
        End Get
        Set(ByVal value As String)
            _NRO_DOCUMENTO = value
        End Set
    End Property

    Private _MES As String
    Public Property MES() As String
        Get
            Return _MES
        End Get
        Set(ByVal value As String)
            _MES = value
        End Set
    End Property

    Private _PERIODO As String
    Public Property PERIODO() As String
        Get
            Return _PERIODO
        End Get
        Set(ByVal value As String)
            _PERIODO = value
        End Set
    End Property

End Class
