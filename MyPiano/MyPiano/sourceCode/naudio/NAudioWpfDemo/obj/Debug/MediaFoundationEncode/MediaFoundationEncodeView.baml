   M S B A M L   `   `   `  ����  NAudioWpfDemoC    =NAudioWpfDemo.MediaFoundationEncode.MediaFoundationEncodeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5	   
   �� $��Encode��6   $
��Left=�6D   $��129,292,0,0q�6_   $	��Top=�6t   $��75��6�   ��6"   �� *EncodeCommand+6�   �� 5
   
   $����Demonstrates using Media Foundation to Encode audio from PCM. Requires Windows Vista and above, and depends on the necessary encoders being installed on your PC. Currently a work in progress, do not rely on this.��6   $
��Left=�5      $��	10,10,0,0q�6/   $	��Top=�6B   $��57��6Z   $
��Wrap=�6f   �� 5   
   $��129,135,49,0q�6   $	��Top=�6)   ��6A   �� *OutputFormats+  �� SelectedItem  6g   �� *SelectedOutputFormat+ �� Mode$ TwoWay=���5      �� 5      .R�5      �� ��6    �� *Name+68   5      5      �� 5   
   $��129,162,49,0q�6   $	��Top=�6)   ��6A   �� *SupportedMediaTypes+  6m   �� *SelectedMediaType+$ TwoWay=���5      �� 5      .R�5      �� ��6    �� *Name+5      5      �� 5   
   $��98��6   $��129,189,49,0q�5       �� TextWrapping$
 Wrap=�6(   $	��Top=�5       �� AcceptsReturn .  �� 
IsReadOnly . ��5   <   �� *SelectedMediaType.Description+5   ?   �� 5   
   $��Input File:��6   $
��Left=�6&   $��	10,72,0,0q�6A   $	��Top=�6T   �� 5   
   $��23��6   $��129,75,49,0q�6   $ NoWrap=�63   $	��Top=�6d    . ��6I   �� *	InputFile+6|   �� 5   
   $	��...��6   $��	0,75,10,0q�6J   $	��Top=�6]   $��Right=�6u   $��34��6�   ��6   �� *SelectInputFileCommand+6�   �� 5    
   $��Encoding Format:��6   $
��Left=�6+   $��
10,131,0,0q�6F   $	��Top=�6Z   �� 5!   
   $��Input PCM Format:��6   $
��Left=�6,   $��
10,104,0,0q�6G   $	��Top=�6[   �� 5"   
   $��23��6   $��129,107,49,0q�6   $
 Wrap=�64   $	��Top=�6e    . ��6H   �� *InputFormat+6}   �� 5#   
   $��Encoder Settings:��6   $
��Left=�6,   $��
10,162,0,0q�6G   $	��Top=�6[   5&      5'      