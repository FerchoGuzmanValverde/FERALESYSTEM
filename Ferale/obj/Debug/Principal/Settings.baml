   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Ferale.PrincipalFerale.Principal  5   	       Ferale.Principal.Settings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Ferale.Principal     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Settings��5	   	   $	��500��6   $	��350��6'    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	   .��5      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF7DA630��6#   � 5      $ 	#FF7DA630��6#    � Offset$ 1Q�65   � 5      $ 	#FF7DA630��6#   $ 0.546Q�65   5      5      �� 5   
   $	��280��6   $	��305��6    $��Bottom=�6-   $��
35,0,35,80q�6H    �� RadiusY$ 10��6\   	 �� RadiusX$	 10��6i   
�������
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      � 5   
   $��Bottom=�6   $��
35,0,35,80q�6*   $	��305��6>   .+�5       �� $��CONFIGURACIÓN DE USUARIO��6   $��Center=�67   $	��Top=�6T   $��5q�6l   
�������$��18(�6�   �� 5!      $��Center=�6   $��15,37,15,10q�64   $	��258��6I   .+�5"      �� -   5         ��Name$ 
txtUsuario��5"      $
��0,10q�6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��6<    %  !MaterialDesignFloatingHintTextBox#��[  6e   $��Champagne & Limousines)�6�   $��18(�6�   G� 5#      -   5         G�Name$ txtPassword��5#      $
��0,10q�63   $ Contraseña��6A    ) %MaterialDesignFloatingHintPasswordBox#��[ 6m   $��Champagne & Limousines)�6�   $��18(�6�   G� 5$      -   5        $ txtRePassword��5$      $
��0,10q�65   $ Verificar Contraseña��6C   #��[ 6y   $��Champagne & Limousines)�6�   $��18(�6�   �� 5%      -   5        $ 	txtCodigo��5%      $
��0,10q�6-   $ Codigo de Acceso��6;   #��[  6m   $��Champagne & Limousines)�6�   $��18(�6�   5&      5'      �� 5(   
   -   5        $��
btnGuardar��5(      $	��150��6#   $��Center=�6/   $��Bottom=�6L   $��100,0,100,69q�6g   $��Guardar��6}   ���	#FF2A5D9E
����������#1b5e206�   �� 5)   
   $6��0Por seguridad no comparta su Usuario/Contraseña��6   $��Center=�6K   $��Bottom=�6h   $��30q�6�   
������� � Cursor$
 Hand��6�   A� 5*   
   $	��100��6   $	��100��6   $��Center=�6+   $��Center=�6F   $��127,10,123,390q�6c   ��5+      �� 5,       �� ImageSource$ ../img/logoHoja.jpg��6    j� Stretch$
 Fill=�6A   5.      �� 5/   
   -   5        $��btnSalir��5/      $
��Left=�6!   $��	320,0,0,0q�6<   $	��Top=�6O   $��30��6g   $��30��6r   $��0q�6�   ���	#FF245AA4��6~   Z� ��6�   Z� .��50      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   51      52      53      