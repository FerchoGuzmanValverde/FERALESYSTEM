   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Ferale.Controles.ReportesFerale.Controles.Reportes  5      h dSAPBusinessObjects.WPF.Viewer, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304tRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.ViewerSAPBusinessObjects.WPF.Viewer 5      7    1Ferale.Controles.Reportes.ControlReporteLimpiezas   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Ferale.Controles.Reportes     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ViewerRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer  5      -   5        $	��706��5
      $	��961��6   $��Roboto)�6'   .��5      #  MaterialDesignThemes.Wpf.Card  $��40,40,40,38q�6   $��20 20 20 20q�6/   $��Stretch=�6E   .��5   
   � .+�5      8  2SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer  -   5           Name$  rvLimmpiezas��5   *   $
��Left=�6@   $	��450��6[   $��
10,128,0,0q�6h   $	��Top=�6|   $	��821��6�   �� 5      $��FILTROS��6   $
��Left=�6(   $	��100��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��821��6{   .��5      � .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ dpFechaInicio��5   !   $
��Left=�68   $��	10,20,0,0q�6S   $	��Top=�6f   $��30��6~   $	��153��6�     5      -   5        $ 
dpFechaFin��5   !   $
��Left=�65   $��
190,20,0,0q�6P   $	��Top=�6d   $��30��6|   $	��153��6�   �� 5      -   5         ��Name$ cbxTipoLimmpieza��5      $
��Left=�69   $��
386,23,0,0q�6T   $	��Top=�6h   $	��180��6�   $��27��6�   �� 5      -   5        $ cbxEstablecimiento��5      $
��Left=�6;   $��
613,23,0,0q�6V   $	��Top=�6j   $	��180��6�   $��27��6�   	� 5      -   5         	�Name$ 
rbtFiltro1��5   "    	� 	GroupName$ filtros��66   $��Filtrar entre 2 fechas��6J   $
��Left=�6k   $��10,2,0,0q�6�   $	��Top=�6�   $	��153��6�    d� 	IsChecked$
 TrueY�6�   	� 5      -   5        $ 
rbtFiltro2��5   "   $ filtros��66   $"��Filtrar por tipo de limpieza��6J   $
��Left=�6q   $��	386,0,0,0q�6�   $	��Top=�6�   $	��180��6�   	� 5      -	   5        $ 
rbtFiltro3��5   "   $ filtros��66   $!��Filtrar por establecimiento��6J   $
��Left=�6p   $��	613,0,0,0q�6�   $	��Top=�6�   $	��180��6�   5      5      �� 5      -
   5         ��Name$ 	btnBuscar��5      $��GENERAR��6(   $
��Left=�6:   $��
706,10,0,0q�6U   $	��Top=�6i   $	��125��6�   $��31��6�   
�������6�   5      5      5      