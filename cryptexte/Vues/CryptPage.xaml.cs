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

        // Afficher ou utiliser le texte crypt�
        textecrypte.Text = texteCrypte;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        string cleTexte = clecrypt.Text;
        int cle = CalculerValeurNumerique(cleTexte);
        string texteCrypte = textecrypte.Text;
        string texteDecrypte = DecrypterTexte(texteCrypte, cle);

        // Afficher ou utiliser le texte d�crypt�
        textedecrypte.Text = texteDecrypte;
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

        // R�duire la somme si elle est sup�rieure � 26
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
                // D�terminer si la lettre est en majuscule ou en minuscule
                bool estMajuscule = char.IsUpper(c);

                // Obtenir la position de la lettre dans l'alphabet (0-25)
                int positionLettre = char.ToUpper(c) - 'A';

                // Effectuer le d�calage avec la cl�
                int positionCryptee = (positionLettre + cle) % 26;

                // Convertir la position crypt�e en lettre
                char lettreCryptee = (char)(positionCryptee + 'A');

                // Convertir en minuscule si n�cessaire
                if (!estMajuscule)
                {
                    lettreCryptee = char.ToLower(lettreCryptee);
                }

                texteCrypte += lettreCryptee;
            }
            else
            {
                // Si ce n'est pas une lettre, ajouter le caract�re tel quel
                texteCrypte += c;
            }
        }
        return texteCrypte;
    }
    public string DecrypterTexte(string texteCrypte, int cle)
    {
        string texteDecrypte = "";
        foreach (char c in texteCrypte)
        {
            if (char.IsLetter(c))
            {
                // D�terminer si la lettre est en majuscule ou en minuscule
                bool estMajuscule = char.IsUpper(c);

                // Obtenir la position de la lettre dans l'alphabet (0-25)
                int positionLettre = char.ToUpper(c) - 'A';

                // Effectuer le d�calage inverse avec la cl�
                int positionDecryptee = (positionLettre - cle + 26) % 26; // +26 pour �viter les nombres n�gatifs

                // Convertir la position d�crypt�e en lettre
                char lettreDecryptee = (char)(positionDecryptee + 'A');

                // Convertir en minuscule si n�cessaire
                if (!estMajuscule)
                {
                    lettreDecryptee = char.ToLower(lettreDecryptee);
                }

                texteDecrypte += lettreDecryptee;
            }
            else
            {
                // Si ce n'est pas une lettre, ajouter le caract�re tel quel
                texteDecrypte += c;
            }
        }
        return texteDecrypte;
    }

    public async Task TenterDecrypterSansCle(string texteCrypte)
    {
        string resultats = "";
        for (int cle = 1; cle <= 25; cle++)
        {
            string texteTente = DecrypterTexte(texteCrypte, cle);
            resultats += $"Cl� {cle}: {texteTente}\n";
            // Accumuler les r�sultats dans une cha�ne
        }

        // Afficher tous les r�sultats dans une seule alerte
        textedecrypte.Text = resultats;
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {

        TenterDecrypterSansCle(textecrypte.Text);
    }
}