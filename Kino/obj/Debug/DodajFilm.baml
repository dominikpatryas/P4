   M S B A M L   `   `   `  ����?  ;Kino, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KinoKino  5   	       Kino.DodajFilm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Kino     5   	   X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Cinema��5	   	   $	��450��6   $	��800��6%   .��5
      � -   5         �Name$
 Grid��5
      .+�5   
   �� -   5         ��Name$ textbox_nazwa��5      $
��Left=�6*   $��40��6E   $��
189,36,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��300��6�   $��20(�6�   �� 5   
   -   5        $ textbox_gatunek��5      $
��Left=�6+   $��40��6F   $��189,100,0,0q�6R   $
 Wrap=�6g   $	��Top=�6|   $	��300��6�   $��20(�6�   �� 5   
   -   5        $ textbox_rok��5      $
��Left=�6'   $��40��6B   $��189,159,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��300��6�   $��20(�6�   �� 5   
   -   5        $ textbox_opis��5      $
��Left=�6(   $	��132��6C   $��189,207,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��300��6�   $��20(�6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5          Name$ 	date_film��5      $
��Left=�61   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�6L      FormatString$ MM-dd-yy HH:mm��6]      
TimeFormat$ Custom=�5         TimeFormatString$ HH:mm��5      $��189,363,0,0q�67   $	��Top=�6L   $��31��6d   $	��300��6p   $��15(�6|   �� 5   
   -   5        	 ��Name$	 button_dodajfilm��5      $��Dodaj��6+   $
��Left=�6;   $��541,363,0,0q�6V   $	��Top=�6k   $	��103��6�   $��31��6�   $��Corbel)�6�   $��18(�6�   �� 5   
   $��Tytuł��6   $
��Left=�6    $��	25,36,0,0q�6;   $	��Top=�6N   
 J� RenderTransformOrigin$
 0.326,0.137&�6f   $��20(�6�   $��40��6�   $	��101��6�   $��Javanese Text)�6�   
�������6�   �� 5   
   $��Gatunek ��6   $
��Left=�6#   $��
25,100,0,0q�6>   $	��Top=�6R   $
 0.326,0.137&�6j   $��20(�6�   $��40��6�   $	��101��6�   $��Javanese Text)�6�   
�������6�   �� 5   
   $��Rok produkcji��6   $
��Left=�6(   $��
25,159,0,0q�6C   $	��Top=�6W   $
 0.326,0.137&�6o   $��20(�6�   $��40��6�   $	��141��6�   $��Javanese Text)�6�   
�������6�   �� 5   
   $��
Opis filmu��6   $
��Left=�6%   $��
25,207,0,0q�6@   $	��Top=�6T   $
 0.326,0.137&�6l   $��20(�6�   $��42��6�   $	��125��6�   $��Javanese Text)�6�   
�������6�   �� 5   
   $��Data i godzina��6   $
��Left=�6)   $��
25,354,0,0q�6D   $	��Top=�6X   $
 0.326,0.137&�6p   $��20(�6�   $��47��6�   $	��141��6�   $��Javanese Text)�6�   
�������6�   �� 5   
   -   5         ��Name$ dodano_label��5      $��
��6&   $
��Left=�6;   $��672,354,0,0q�6V   $	��Top=�6k   $	��112��6�   $��47��6�   5      5       