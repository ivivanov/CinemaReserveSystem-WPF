   M S B A M L   `   `   `  ����B  >WpfExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfExam.ViewModelsWpfExam.ViewModels  5   	   7 clr-namespace:WpfExam.ConvertersWpfExam.Converters  5   	   -clr-namespace:WpfExam.ViewsWpfExam.Views  5   	       WpfExam.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7
ViewModels clr-namespace:WpfExam.ViewModels     5   	   7
Converters clr-namespace:WpfExam.Converters     5   	   -Viewsclr-namespace:WpfExam.Views     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1200��6)    � DataContext 5      %   WpfExam.ViewModels.AppViewModel  5	   
    � 	Resources 5       �� DataType)   #WpfExam.ViewModels.CinemasViewModel   WpfExam.Views.CinemasView+   %WpfExam.ViewModels.AllMoviesViewModel!   WpfExam.Views.AllMoviesView(   "WpfExam.ViewModels.SearchViewModel#   WpfExam.Views.SearchMovieView)   #WpfExam.ViewModels.ReserveViewModel	   WpfExam.Views.ReserveView2
   ,WpfExam.Converters.BoolToVisibilityConverter   boolToVisibilityConverter��%I  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)&	  �     �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      
  5   
   6/   5      .��5       �  � RowDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��9* �6   �� 5&      $��* �6   .+�5)   
   �� $��0��6   $��Center=�6"   .+�5*      �� $��28(�6   $��Comic Sans MS, Verdana)�6&   Cinema Reservation System6f   5+      ]� 5-   
   -   5        $��Header��5-   <   $��Center=�6   $��1��6/   $��5q�6J   ��.  .+�5.      �� $
��Left=�6   $��5q�6+   $��5q�66   $	��100��6B   ��6Q   ��  �� Path$ OpenCinemasViewCommand�.��6�   	Cinemas6�   �� 5/      $
��Left=�6   $��5q�6+   $��5q�66   $	��100��6B   ��6Q   �� $ OpenAllMoviesViewCommand�.��6�   
All Movies6�   �� 50      $
��Left=�6   $��5q�6+   $��5q�66   $	��100��6B   ��6Q   �� $ OpenSearchViewCommand�.��6�   Search Movies6�   51      �� 53   
   $��16(�6   $��2��6"   ��6/   �� $ CurrentViewModel.Message�6`   � 55   
   $��3��6   .+�56      ]� .+�57      �� -   5        $��HeaderContainer��57      $	��Top=�59      y�58      �� $ LoggedInUser� �� 	Converter# [  .+�5:      �� ��6#   �� *
ViewModels+��5;      �� 5<      .R�5=   "   ��  �� Orientation$ 
Horizontal=�6-   5>      ��5@      �� 5A      .R�5B   "   �� ��6)   �� *Name+��5C   %   �� $! DataContext.ChangeViewModel� �� RelativeSource �� 	 �� AncestorType"	 ���5D   %   �� 5E      5G      5H      �� 5I      $��Bottom=�6!   ��69   �� *CurrentViewModel+5J      5K      �� 5M   
   $��4��6   $��Center=�6"   $��Center=�6?   .+�5N      �� -   5        $��Footer��5N      +)Telerik Academy 2013 - Reservation System6Q   5O      5P      5Q      