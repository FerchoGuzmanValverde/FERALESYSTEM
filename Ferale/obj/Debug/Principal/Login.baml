   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Ferale.PrincipalFerale.Principal  5   	   C&clr-namespace:MaterialDesignThemes.WpfMaterialDesignThemes.Wpf  5   	       Ferale.Principal.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Ferale.Principal     5   	   6wpf&clr-namespace:MaterialDesignThemes.Wpf     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  Login��5
   	   $	��400��6   $	��600��6$    � 
ResizeMode$ NoResize=�60    � WindowStyle$
 None=�6F    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   ��  �� RadiusY$ 8��6    �� RadiusX$ 8��6    
�������6,   �� 5   
   $(��"/Ferale;component/img/logoHoja.jpg��6   $��	310,0,0,0q�6<   $��Uniform=�6O   �� 5   
   $��	310,0,0,0q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 #7DA630��6#   
 � Offset$
 0.807Q�63   � 5      $	 #7DA630��6#   $
 0.217Q�63   � 5      $	 	#FF7DA630��6#   $
 0.537Q�65   5      5      �� 5   
   $��20,10,290,10q�6   .+�5      �� $��Login��6   $��Segoe UI Black)�6$   $��24(�6@   $
��0,10q�6N   $	��Top=�6\   $
��Left=�6t   �� 5      $	��0,5q�6    �� Orientation$ 
Horizontal=�6&   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6*   $��Center=�69   ���#7070706T   �� 5      -   5         ��Name$ 
txtUsuario��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��6.      
IsFloating . $	��250��6�   $��5q�6�   5      �� 5      $ 
Horizontal=�6   .+�5        $	 Key=�6*   $��Center=�65   ���#7070706P   G� 5       -   5         G�Name$ txtPassword��5       $ Password��63    . $	��250��6�   $��5q�6�   5!      �� 5"      $ 
Horizontal=�6   $��Center=�62   .+�5#      �� -   5         ��Name$ btnIngresar��5#      $��Center=�6.   $��Impact)�6K   $��18(�6_   ���	#FF7DA630���	#FF7DA630$��10q�6�   .��5$      �� 
�������.��6/   
INGRESAR69   5%      �� 5&      -   5        $ btnSalir��5&      $��Center=�6+   $��Impact)�6H   $��18(�6\   ���	#FF7DA630���	#FF7DA630$��10q�6�   .��5'      �� 
�������.��6/   SALIR66   5(      5)      �� 5*      $ 
Horizontal=�6   $	��5,5q�62   $��Center=�6?   .+�5+      �� $��Acceder con:��6   ���#707070$��Center=�6D   �� 5,      -   5        $ btnFacebook��5,      $��Center=�6.   $��Impact)�6K   $��18(�6_   ���	#FF3D56AC���	#FF3D56AC$��5q�6�   .��5-        $ Facebook=�6.   $��Center=�6>   
�������6Y   5.      �� 5/      -   5        $ 	btnGoogle��5/      $��Center=�6,   $��Impact)�6I   $��18(�6]   ���	#FFE05959���	#FFE05959$��5q�6�   .��50        $ 
GooglePlus=�6.   $��Center=�6@   
�������6[   51      52      �� 53      $ 
Horizontal=�6   $	��5,5q�62   $
��Left=�6?   .+�54      �� $��Registrarse:��6   ���#707070$��Center=�6D   �� 55      -   5        $ btnRegistrarse��55      $
��auto��61   $��Center=�6>   $��Impact)�6[   $��18(�6o   ���	#FF7DA630���	#FF7DA630$��5q�6�   .��56      �� 
�������.��6/   REGISTRARSE6<   57      58      �� 59      $ 
Horizontal=�6   .+�5:      �� $
��Left=�6   $	��Top=�67   $
��Wrap=�6O   ���#707070¿No recuerda su contraseña?6�   �� 5;      -	   5         ��Name$ btnRecuperar��5;      $
��Left=�62   $	��Top=�6M   $
��Wrap=�6e   ���	#FF2468AC$
��10 0q�6�   	Recuperar6�   5<      �� 5=      $
��Left=�6   $	��Top=�63   $
��Wrap=�6K   ���#707070$
��0 10q�6t   :8Por seguridad, recomendamos no compartir su contraseña.6�   5>      �� 5?   
   $��
310,0,0,50q�6   .+�5@      �� -
   5        $ Close��5@      $��55��6$   $��0,0,0,0q�6/   $��Right=�6@   $��36��6p   .��5A        $ Close=�6*   5B      A� 5C      $	��150��6   $	��150��6#   $��Center=�6/   $��Center=�6J   $
��70,0q�6g   ��5D      �� 5E       �� ImageSource$ ../img/logoHoja.jpg��6"    j� Stretch$
 Fill=�6E   5G      �� 5H      $��FERALE��6   
�������$��Center=�69   $	��280��6V   $��24(�6b   $��Champagne & Limousines)�6p   $
��Wrap=�6�    �� TextAlignment$ Center=�6�   $��5,20,5,0q�6�   �� 5I      $6��0Bienvenido al sistema de gestión de la empresa.��6   
�������$��18(�6b   $��Champagne & Limousines)�6p   $
��Wrap=�6�   $ Center=�6�   $��	10 30 0 0q�6�   5J      5K      5L      