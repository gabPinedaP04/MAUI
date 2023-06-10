namespace todolist;

public partial class MainPage : ContentPage
{
	int indexList = 0;
	string textoAnadir = "";
	public MainPage()
	{
		InitializeComponent();
	}

	List<string> recordatorios = new List<string>();

	public List<string> Recordatorios
	{
		get => recordatorios;
		set
		{
			recordatorios = value;
			OnPropertyChanged();
		}
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		acomodar();
    }

	

    private void btnAnadir_Clicked(object sender, EventArgs e)
    {

        if(!string.IsNullOrEmpty(entryTexto.Text) )
		{
			agregarAlista();
            reAcomodar();
        }
		else
		{
			return;
		}

    }

    public void agregarAlista()
	{
		textoAnadir = entryTexto.Text;
		recordatorios.Add(textoAnadir);
		

        var newLabel = new Label
        {
            Text = recordatorios[indexList],
            FontSize = 20,
			FontFamily = "apple"
        };


		var newCheckbox = new CheckBox
		{
			IsChecked = false
		};

		var newButton = new Button
		{
			Text="Eliminar"
		};


        var newStack = new HorizontalStackLayout
        {
			Margin = 10,
			Spacing =10,
			HorizontalOptions= LayoutOptions.Center,
            Children = { newCheckbox, newLabel, newButton }
        };

        newButton.Clicked += (s, e) =>
        {
            MyStack.Children.Remove(newStack);
        };
		newCheckbox.CheckedChanged += (s, e) =>
		{
			newLabel.TextDecorations = newCheckbox.IsChecked ? TextDecorations.Strikethrough : TextDecorations.None;
		};


        MyStack.Children.Add(newStack);



        indexList++;
    }

	public void acomodar()
	{
		entryTexto.IsVisible=true;
		btnAgregar.IsVisible=false;
		btnAnadir.IsVisible=true;
	}

	public void reAcomodar()
	{
		btnAnadir.IsVisible = false;
		btnAgregar.IsVisible = true;
		entryTexto.IsVisible=false;
		entryTexto.Text = string.Empty;	
	}
}

