   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Ferale.Controles.Registros.VentanasEmpleado+Ferale.Controles.Registros.VentanasEmpleado  5   	   H    BFerale.Controles.Registros.VentanasEmpleado.InsertarEditarEmpleado   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Klocal9clr-namespace:Ferale.Controles.Registros.VentanasEmpleado     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  InsertarEditarEmpleado��5   	   $��631.699��6(   $��1307.666��69    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      5      5      �� 5   
   $��NUEVO EMPLEADO��6   $��
501,49,0,0q�6)   $	��Top=�6=   $��62��6U   $��36(�6a   $
��Left=�6o   $	��345��6�   #  MaterialDesignThemes.Wpf.Card  5   
   $	��402��6   $��
40,111,0,0q�6+   $
��Left=�6?   $	��784��6Z   .��5      � .+�5      �� -   5         ��Name$ 	txtNombre��5      $��0��6.   $��0��6;    % !MaterialDesignFloatingHintTextBox#��[ 6K   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombres��6�   $��	53,30,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtPrimerApellido��5      $��0��66   $��0��6C   #��[ 6S   $	��Top=�6�   $ Apellido Paterno��6�   $��	53,90,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtSegundoApellido��5      $��0��67   $��0��6D   #��[ 6T   $	��Top=�6�   $ Apellido Materno��6�   $��
53,152,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtCi��5      $��0��6*   $��0��67   #��[ 6G   $	��Top=�6�   $ Cedula de Identidad��6�   $��
53,212,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpFechaNacimiento��5      $
��Left=�68   $��
53,277,0,0q�6S   $	��Top=�6g   $	��303��6   $��42��6�   $ Fecha de Nacimiento��6�   �� 5      -   5        	 ��Name$	 cbxSexo��5      $
��Left=�6,   $��
53,336,0,0q�6G   $	��Top=�6[   $	��303��6s   $��42��6   .@�5       �� 
 �� 
IsSelected
 . .��65   	Masculino6@   �� 5!      .��6#   
Femenino6-   5"      �� 5#      -	   5        $ txtNroCuenta��5#      $��0��61   $��0��6>   #��[ 6N   $	��Top=�6�   $ Nro. Cuenta Bancaria��6�   $��
420,30,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5$      -
   5        $	 cbxAreaEmpresa��5$      $
��Left=�63   $��
420,90,0,0q�6N   $	��Top=�6b   $	��303��6z   $��42��6�   5%      �� 5&      -   5        $ txtTelefono��5&      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Telefono de Contácto��6�   $��420,152,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5'      -   5        $	 cbxCargo��5'      $
��Left=�6-   $��420,212,0,0q�6H   $	��Top=�6]   $	��303��6u   $��42��6�   .@�5(      �� 
 . $��Administrador��65   �� 5)      $��Operador��6#   �� 5*      $��Cajero��6#   5+      �� 5,      -   5        $ txtDomicilio��5,      $��0��61   $��0��6>   #��[ 6N   $	��Top=�6�   $ 	Domicilio��6�   $��420,277,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6
  5.      5/        50   
   -   5          Name$ cardGuardar��50      $��42��63     	BlueBrush#��[ 6?   #��[ 6g   $��193,544,0,0q�6�   $
��Left=�6�   $	��226��6�   .��51      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $��Right=�6^   $��Center=�6z   $��	0,10,73,8q�6�   52        53   
   -   5        $ cardCancelar��53      $��42��64   #��[ 6@   #��[ 6h   $��443,544,0,0q�6�   $
��Left=�6�   $	��226��6�   .��54      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   55        56   
   $	��475��6   $��851,111,0,0q�6+   $
��Left=�6@   $	��418��6[   .��57      � .+�58      �� -   5        $ 	txtCorreo��58      $��0��6.   $��0��6;   #��[ 6K   $	��Top=�6�   $ Correo��6�   $��	53,39,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 59      $��53,124,62,48q�6   $��IMAGEN DE PERFIL��61   .��5:      �� -   5         ��Name$ 	imgPerfil��5:      $	��287��6/   $��0,0,0,-6q�6;   5;      5>      5?      5@      5A      