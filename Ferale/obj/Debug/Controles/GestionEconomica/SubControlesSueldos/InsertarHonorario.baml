   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:Ferale.Controles.GestionEconomica.SubControlesSueldos5Ferale.Controles.GestionEconomica.SubControlesSueldos  5   	   M    GFerale.Controles.GestionEconomica.SubControlesSueldos.InsertarHonorario   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   UlocalCclr-namespace:Ferale.Controles.GestionEconomica.SubControlesSueldos     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  InsertarHonorario��5   	   $��737.645��6#   $��562.246��64    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      �� 5      $��NUEVO HONORARIO��6   $��98,10,0,-10q�62   $	��Top=�6G   $��62��6_   $��36(�6k    J� RenderTransformOrigin$ -0.52,0.898&�6y   $
��Left=�6�   $	��347��6�   5      5      #  MaterialDesignThemes.Wpf.Card  5   
   $��
54,111,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��511��6q   .��5      � $��0,0,10,0q�6   .+�5      �� -   5         ��Name$ txtMontoTotalCancelado��5      $��0��6;   $��0��6H    % !MaterialDesignFloatingHintTextBox#��[ 6X   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Total Cancelado��6�   $��	53,30,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtDiaCompleto��5      $��0��63   $��0��6@   #��[ 6P   $	��Top=�6�   $ Dias Completos de Trabajo��6�   $��	53,90,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtMedioDia��5      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Medios Dias Trabajados��6�   $��
53,155,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtPagoMedioDia��5      $��0��64   $��0��6A   #��[ 6Q   $	��Top=�6�   $ Pago Medio/Dia��6�   $��
53,228,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  (  "System.Windows.Controls.DatePicker  5      -   5        	  Name$	 dateDiaFinalPagado��5      $
��Left=�69   $��
53,305,0,0q�6T   $	��Top=�6h   $��39��6�   $	��303��6�   $ Ultimo Día Cancelado��6�   
   
IsFloating
 . 6�   �� 5      -   5        $ txtEmpleado��5      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Nombre Empleado��6�   $��
53,375,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -	   5         ��Name$ cbxMes��5      $
��Left=�6+   $��
53,443,0,0q�6F   $	��Top=�6Z   $	��303��6r   $��41��6~   $	 Mes��6�   5!      5"        5#   
   -
   5          Name$ cardGuardar��5#      $��51��63     	BlueBrush#��[ 6?   #��[ 6g   $��291,649,0,0q�6�   $
��Left=�6�   $	��196��6�   .��5$      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $	��Top=�6^   $��	0,14,49,0q�6v   $��Right=�6�   $��89��6�   5%        5&   
   -   5        $ cardCancelar��5&      $��52��64   #��[ 6@   #��[ 6h   $��
54,648,0,0q�6�   $
��Left=�6�   $	��202��6�   .��5'      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   5(      5)      5*      