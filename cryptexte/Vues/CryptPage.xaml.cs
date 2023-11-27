namespace cryptexte.Vues;

public partial class CryptPage : ContentPage
{
	public CryptPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        int maCle = this.CalculerValeurNumerique(clecrypt.Text);
        string texteACrypter = texteacrypter.Text;
        string texteCrypte = CrypterTexte(texteACrypter, maCle);

        // Afficher ou utiliser le texte crypté
        textecrypte.Text = texteCrypte;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
    }
    public int CalculerValeurNumerique(string texte)
    {
        int valeurTotale = 0;
        foreach (char c in texte)
        {
            if (char.IsLetter(c))
            {
                char lettreMaj = char.ToUpper(c);
                int valeurLettre = lettreMaj - 'A' + 1;
                valeurTotale += valeurLettre;
            }
        }

        // Réduire la somme si elle est supérieure à 26
        while (valeurTotale > 26)
        {
            valeurTotale = ReduireSomme(valeurTotale);
        }

        return valeurTotale;
    }

    private int ReduireSomme(int nombre)
    {
        int somme = 0;
        while (nombre > 0)
        {
            somme += nombre % 10;
            nombre /= 10;
        }
        return somme;
    }
    public string CrypterTexte(string texte, int cle)
    {
        string texteCrypte = "";
        foreach (char c in texte)
        {
            if (char.IsLetter(c))
            {
                // Déterminer si la lettre est en majuscule ou en minuscule
                bool estMajuscule = char.IsUpper(c);

                // Obtenir la position de la lettre dans l'alphabet (0-25)
                int positionLettre = char.ToUpper(c) - 'A';

                // Effectuer le décalage avec la clé
                int positionCryptee = (positionLettre + cle) % 26;

                // Convertir la position cryptée en lettre
                char lettreCryptee = (char)(positionCryptee + 'A');

                // Convertir en minuscule si nécessaire
                if (!estMajuscule)
                {
                    lettreCryptee = char.ToLower(lettreCryptee);
                }

                texteCrypte += lettreCryptee;
            }
            else
            {
                // Si ce n'est pas une lettre, ajouter le caractère tel quel
                texteCrypte += c;
            }
        }
        return texteCrypte;
    }

}