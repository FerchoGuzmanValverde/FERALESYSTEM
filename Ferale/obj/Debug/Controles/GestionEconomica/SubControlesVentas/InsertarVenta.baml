   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null{Bclr-namespace:Ferale.Controles.GestionEconomica.SubControlesVentas4Ferale.Controles.GestionEconomica.SubControlesVentas  5   	   H    BFerale.Controles.GestionEconomica.SubControlesVentas.InsertarVenta   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   TlocalBclr-namespace:Ferale.Controles.GestionEconomica.SubControlesVentas     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  InsertarVenta��5   	   $��737.645��6   $��998.329��60    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      �� 5      $��NUEVA VENTA��6   $��376,10,0,-10q�6.   $	��Top=�6D   $��62��6\   $��36(�6h    J� RenderTransformOrigin$ -0.52,0.898&�6v   $
��Left=�6�   $	��243��6�   5      5      #  MaterialDesignThemes.Wpf.Card  5   
   $��
54,111,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��427��6q   .��5      � $��0,0,10,0q�6   .+�5      �� -   5         ��Name$ txtDescuento��5      $��0��61   $��0��6>    % !MaterialDesignFloatingHintTextBox#��[ 6N   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Descuento %��6�   $��	53,30,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6
  6  �� 5      -   5        $ txtAdelanto��5      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Adelato��6�   $��	53,90,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  6  �� 5      -   5        $ 
txtCliente��5      $��0��6/   $��0��6<   #��[ 6L   $	��Top=�6�   $ NIT Cliente��6�   $��
53,155,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6	  �� 5      -   5        	 ��Name$	 cbxEstadoEntrega��5      $
��Left=�65   $��
53,245,0,0q�6P   $	��Top=�6d   $	��303��6|   $��46��6�   $ Estado Entrega��6�   
   
IsFloating
 . .@�5      ��  �� 
IsSelected . .��65   	Entregado6@   �� 5      .��6#   	Pendiente6.   �� 5      .��6#   	Cancelado6.   5       5"      5#        5$   
   -   5          Name$ cardGuardar��5$      $��51��63     	BlueBrush#��[ 6?   #��[ 6g   $��291,635,0,0q�6�   $
��Left=�6�   $	��196��6�   .��5%      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $	��Top=�6^   $��	0,14,49,0q�6v   $��Right=�6�   $��89��6�   5&        5'   
   -   5        $ cardCancelar��5'      $��52��64   #��[ 6@   #��[ 6h   $��
54,634,0,0q�6�   $
��Left=�6�   $	��202��6�   .��5(      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   5)        5*   
   $��516,111,0,0q�6   $
��Left=�63   $	��433��6N   $	��Top=�6Z   $	��575��6r   .��5+      � $
��Left=�6   $	��555��6.   $��	10,10,0,0q�6;   $	��Top=�6N   $	��413��6f   .+�5,      �� -	   5        $ txtCantidad��5,      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Cantidad��6�   $��
175,10,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��150��6  �� 5-      -
   5        $ txtPrecioUnitario��5-      $��0��66   $��0��6C   #��[ 6S   $	��Top=�6�   $ Precio Unitario��6�   $��	10,10,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��151��6  �� 5.      -   5        $	 cbxTipoProducto��5.      $
��Left=�64   $��	10,74,0,0q�6O   $	��Top=�6b   $	��315��6z   $��46��6�   $ Estado Entrega��6�   
 . 6�     5/      -   5        $ btnEditarDetalleVenta��5/   &   $��46��6E   $��355,74,10,0q�6Q   #��[ 6f   #��[ 6�   $ 0.5,0.5&�6�   .��50      �� .+�51        $
 Edit=�62   $��45��6>   $��	0,0,0,-18q�6J   $��48��6]   #��[ 6h   52      53        54      -   5        $ btnAgregarDetalleVenta��54   &   $��46��6F   $��355,10,10,0q�6R   #��[ 6g   #��[ 6�   $ 0.5,0.5&�6�   .��55      �� .+�56        $	 Add=�62   $��45��6=   $��	0,0,0,-18q�6I   $��48��6\   #��[ 6g   57      58        59      -   5        $ cardDeleteItem��59   &   $��46��6>   $��355,140,10,0q�6J   #��[ 6`   #��[ 6�   $ 0.5,0.5&�6�   .��5:      �� .+�5;        $ Delete=�62   $��45��6@   $��	0,0,0,-18q�6L   $��48��6_   #��[ 6j   5<      5=      �� 5>      $��DETALLE PRODUCTOS��6   $
��Left=�66   $	��334��6Q   $��
10,211,0,0q�6^   $	��Top=�6r   $	��393��6�   .��5?      �� -   5         ��Name$ lstDetalleProductos��5?      $	��281��6;   $	��Top=�6H   $	��377��6`   6l   5@      �� 5A      -   5        $	 cbxProducto��5A      $
��Left=�60   $��
10,140,0,0q�6K   $	��Top=�6_   $	��315��6w   $��46��6�   $ Producto��6�   
 . 6�   5B      5C      �� 5D   
   -   5         ��Name$ lblTotalCompra��5D      $��TOTAL:��6(   $��Right=�69   $��0,563,503,0q�6U   $	��Top=�6j   $��52��6�   $	��433��6�   $��25(�6�   $��Right=�6�   $��Bottom=�6�   $
��Bold)�6�   5E      5F      