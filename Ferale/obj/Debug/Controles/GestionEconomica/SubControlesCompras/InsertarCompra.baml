   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:Ferale.Controles.GestionEconomica.SubControlesCompras5Ferale.Controles.GestionEconomica.SubControlesCompras  5   	   B    <Ferale.Controles.GestionEconomica.SubControlesCompras.Compra   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:Ferale.Controles.GestionEconomica.SubControlesCompras     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  Compra��5   	   $��737.645��6   $��998.329��6)    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      �� 5      $��NUEVA COMPRA��6   $��364,10,0,-10q�6/   $	��Top=�6E   $��62��6]   $��36(�6i    J� RenderTransformOrigin$ -0.52,0.898&�6w   $
��Left=�6�   $	��281��6�   5      5      #  MaterialDesignThemes.Wpf.Card  5   
   $��
54,111,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��427��6q   .��5      � $��0,0,10,0q�6   .+�5      �� -   5         ��Name$ txtNroFactura��5      $��0��62   $��0��6?    % !MaterialDesignFloatingHintTextBox#��[ 6O   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nro. Factura��6�   $��	53,30,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtNroAutorizacion��5      $��0��67   $��0��6D   #��[ 6T   $	��Top=�6�   $ Nro. Autorización��6�   $��	53,90,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtCodigoControl��5      $��0��65   $��0��6B   #��[ 6R   $	��Top=�6�   $ Codigo Control��6�   $��
53,155,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        	 ��Name$	 cbxProveedor��5      $
��Left=�61   $��
53,245,0,0q�6L   $	��Top=�6`   $	��303��6x   $��46��6�   $ 	Proveedor��6�   
   
IsFloating
 . 5      5      5         5!   
   -   5          Name$ cardGuardar��5!      $��51��63     	BlueBrush#��[ 6?   #��[ 6g   $��291,635,0,0q�6�   $
��Left=�6�   $	��196��6�   .��5"      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $	��Top=�6^   $��	0,14,49,0q�6v   $��Right=�6�   $��89��6�   5#        5$   
   -   5        $ cardCancelar��5$      $��52��64   #��[ 6@   #��[ 6h   $��
54,634,0,0q�6�   $
��Left=�6�   $	��202��6�   .��5%      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   5&        5'   
   $��516,111,0,0q�6   $
��Left=�63   $	��433��6N   $	��Top=�6Z   $	��575��6r   .��5(      � $
��Left=�6   $	��555��6.   $��	10,10,0,0q�6;   $	��Top=�6N   $	��413��6f   .+�5)      �� -	   5        $ txtCantidad��5)      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Cantidad��6�   $��
205,10,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��198��6  �� 5*      -
   5        $ txtPrecioUnitario��5*      $��0��66   $��0��6C   #��[ 6S   $	��Top=�6�   $ Precio Unitario��6�   $��	10,10,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��190��6  �� 5+      -   5        $	 cbxMaterial��5+      $
��Left=�60   $��	10,74,0,0q�6K   $	��Top=�6^   $	��315��6v   $��46��6�   $ Estado Entrega��6�   
 . 6�     5,      -   5        $��46��5,   &   $��276,140,88,0q�62   #��[ 6H   #��[ 6p   $ 0.5,0.5&�6�   .��5-      �� .+�5.        $	 Add=�62   $��45��6=   $��	0,0,0,-18q�6I   $��48��6\   #��[ 6g   5/      50        51      -   5        $ cardDeleteItem��51   &   $��46��6>   $��355,140,10,0q�6J   #��[ 6`   #��[ 6�   $ 0.5,0.5&�6�   .��52      �� .+�53        $ Delete=�62   $��45��6@   $��	0,0,0,-18q�6L   $��48��6_   #��[ 6j   54      55      �� 56      $��DETALLE MATERIALES��6   $
��Left=�67   $	��334��6R   $��
10,211,0,0q�6_   $	��Top=�6s   $	��393��6�   .��57      �� -   5         ��Name$ lstDetalleProductos��57      $	��281��6;   $	��Top=�6H   $	��377��6`   58      59      5:      �� 5;   
   -   5         ��Name$ lblTotalCompra��5;      $��TOTAL:��6(   $��Right=�69   $��0,563,503,0q�6U   $	��Top=�6j   $��52��6�   $	��433��6�   $��25(�6�   $��Right=�6�   $��Bottom=�6�   $
��Bold)�6�   5<      5=      