using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText; // O texto que ser� exibido na tela
    public GameObject[] dialogueOptions; // Op��es de respostas do di�logo
    public string[] dialogueLines; // As linhas de di�logo
    private int currentLine = 0; // Linha atual do di�logo
    public RawImage ghost;
    public Texture2D[] bgGhost;




    // Listas de labels para os bot�es
    public string[] positiveLabels; // Labels para a resposta positiva 
    public string[] negativeLabels; // Labels para a resposta negativa 

    void Start()
    {
        dialogueLines = new string[]
        {
            "Ola, permita me apresentar me chamo Fasmo o fantasma j� estou aqui nesta mans�o a tanto tempo que ja perdi a no��o do tempo ", // Linha 0 manda pro 2
            "Bem infelizmente fui traido por quem eu mais confiava e acabei preso aqui.", // Linha 1 - manda pro 2 
            "Bem infelizmente fui traido por quem eu mais confiava e acabei preso aqui.", // Linha 2

            "Bem, para voc� me libertar, antes disso � necessario que eu te conte uma hist�ria", // Linha 3
            "� claro que n�o! a hist�ria � importante, pois voc� tera que responder algumas perguntas que teram haver com ela.", // Linha 4
            "Olha n�o sou eu que faz as regras eu apenas as sigo.", // Linha 5
            "� muito tempo, no alto de uma colina cercada por neblina constante, existia uma mans�o antiga, habitada apenas por um esp�rito conhecido como Fasmo. Ele era um fantasma solit�rio, vagando pelos corredores empoeirados e ouvindo os ecos de uma vida que j� n�o existia.", // Linha 6


            "Durante o dia, a mans�o permanecia em sil�ncio absoluto, mas � noite, Fasmo preenchia os c�modos com sons de passos e sussurros. Ele tinha um segredo: em vida, havia sido um m�sico talentoso, e no sal�o principal da mans�o repousava um velho piano de cauda, onde Fasmo tocava melodias tristes para a lua cheia.", // Linha 7
            "Certo dia, um grupo de jovens corajosos decidiu explorar a mans�o, em busca de aventuras e lendas. Ao entrarem, ouviram uma m�sica melanc�lica ecoando pelos corredores. Intrigados, seguiram o som at� o sal�o principal, onde encontraram Fasmo ao piano..", // Linha 8
            "Para sua surpresa, ele n�o era um esp�rito vingativo, mas sim um fantasma amig�vel, que ansiava por companhia e por algu�m que ouvisse suas composi��es.", // Linha 9
            "A partir daquela noite, a mans�o deixou de ser um lugar assustador e tornou-se um ref�gio para os jovens, que passaram a se reunir ali para ouvir Fasmo tocar e aprender sobre sua vida misteriosa.\r\n\r\n", // Linha 10
            "Agora,as perguntas.", // Linha 11
            "Qual o segredo de Fasmo?.", // Linha 12
            "Certa resposta", // Linha 13

            "Facil �? certo, por que Fasmo tocava melodias tristes no piano?.", // Linha 14
            "Isso mesmo!", // Linha 15

            "O que motivou os jovens a explorar a mans�o?", // Linha 16
            "Espero que tenha gostado de ouvir as hist�rias. At� logo!", // Linha 17
            "Errou!", // Linha 18
            "Se decidir voltar, estarei aqui para compartilhar mais aventuras.", // Linha 19




        };

        positiveLabels = new string[]
        {
            "Oq voc� faz aqui?",// Linha 0
            "Puxa, que pena, h� alguma forma de voc� ser liberto?",// Linha 1
            "Puxa, que pena, h� alguma forma de voc� ser liberto?",// Linha 2
            "S� isso?", // Linha 3
            "Se voc� diz...", // Linha 4
            "Certo, qual a hist�ria?", // Linha 5
            "Certo, e depois?", // Linha 6
            "Certo", // Linha 7
            "Ok...", // Linha 8
            "Hum...", // Linha 9
            "Certo!", // Linha 10
            "Cero,Manda ver!", // Linha 11
            "Ele gostava de tocar piano, por�m ele sempre fez isso sozinho ", // Linha 12
            "Essa foi facil!", // Linha 13
            "Pois ele vivia sozinho", // Linha 14
            "Vai tarde", // Linha 15
            "At� mais!", // Linha 16
            "Que nada, s� fazer um pix de R$100", // Linha 17
            "At� breve biruta", // Linha 17
            
        };

        negativeLabels = new string[] {

            "Oq voc� faz aqui?",// Linha 0
            "Puxa, que pena, h� alguma forma de voc� ser liberto?",// Linha 1
            "Puxa, que pena, h� alguma forma de voc� ser liberto?",// Linha 2
            "S� isso?", // Linha 3
            "Se voc� diz...", // Linha 4
            "Certo, qual a hist�ria?", // Linha 5
            "Certo, e depois?", // Linha 6
            "Certo", // Linha 7
            "Ok...", // Linha 8
            "Hum...", // Linha 9
            "Certo!", // Linha 10
            "Cero,Manda ver!", // Linha 11
            "Ele gostava de tocar piano, por�m ele sempre fez isso sozinho ", // Linha 12
            "Essa foi facil!", // Linha 13
            "Pois ele vivia sozinho", // Linha 14
            "Vai tarde", // Linha 15
            "At� mais!", // Linha 16
            "Que nada, s� fazer um pix de R$100", // Linha 17
            "At� breve biruta", // Linha 17

        };

        // Exibe a primeira linha do di�logo
        ShowDialogueLine();
    }

    // Exibe uma linha de di�logo
    void ShowDialogueLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            ShowOptions();
        }
        else
        {
            EndDialogue();
        }

        if (currentLine < positiveLabels.Length)
        {
            var indexPositiveBtn = 0;
            setNewTextButton(indexPositiveBtn, currentLine);
        }
    }

    // Desativa todas as op��es
    void DisabledAllOptions()
    {
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false);
        }
    }

    // Exibe as op��es de resposta
    void ShowOptions()
    {

        // Exibe op��es com base na linha atual
        switch (currentLine)
        {
            case 0: // Primeira linha de di�logo
            case 1:
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora."
                break;
           case 12: // Primeira decis�o antes das perguntas
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora."
                break;
            case 14: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora."
                break;

            case 16: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            default: // Para todas as outras op��es
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(false); // "N�o, prefiro ir embora
                break;
        }
    }

    // Fun��o para o jogador selecionar uma resposta
    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: // "Sim, me conte mais!"
                HandleYesOption();
                break;

            case 1: // "N�o, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); // Atualiza a linha do di�logo
    }

    // L�gica quando o jogador escolhe "Sim, me conte mais!"
    void HandleYesOption()
    {
        switch (currentLine)
        {
            case 0: // Introdu��o
            case 1: // Op��o inicial de saber mais
                int indexImageFeliz = 4;
                ChangeSprite(indexImageFeliz);
                currentLine = 2; // Avan�a para o Reino dos Drag�es
                break;

            case 11: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 12; // Fala mais sobre os drag�es
                break;

            case 14: // Quando o jogador escolhe saber mais sobre os portais
                currentLine = 13; // Fala mais sobre os portais
                break;

            default: // Para todas as outras op��es
                currentLine += 1; // Apenas avan�a para a pr�xima linha
                int indexImagePadrao = 3;
                ChangeSprite(indexImagePadrao);
                break;
        }
    }

    // L�gica quando o jogador escolhe "N�o, prefiro ir embora."
    void HandleNoOption()
    {
        switch (currentLine)
        {
            case 0: // Introdu��o
            case 12: // Op��o inicial de saber mais
                int indexImage = 0;
                ChangeSprite(indexImage);
                currentLine = 18; //texto de erro 
                break;

            case 18: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 12; // Fala mais sobre os drag�es
                break;

            case 14: // Quando o jogador escolhe saber mais sobre os portais
                currentLine = 13; // Fala mais sobre os portais
                break;

            default: // Para todas as outras op��es
                currentLine += 1; // Apenas avan�a para a pr�xima linha
                int indexImagePadrao = 3;
                ChangeSprite(indexImagePadrao);
                break;
        }
        int indexImageBravo = 0;
        ChangeSprite(indexImageBravo);
       
    }

    void setNewTextButton(int indexDialogOption, int currentLine)
    {
        Text buttonText = dialogueOptions[indexDialogOption].GetComponentInChildren<Text>();
        buttonText.text = positiveLabels[currentLine];
    }
    // Finaliza o di�logo
    void EndDialogue()
    {
        dialogueText.text = "O di�logo terminou. Voc� pode voltar quando quiser!";
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false); // Aqui os bot�es s�o desativados quando o di�logo termina
        }
    }
    public void ChangeSprite(int indexImage)
    {
        //Debug.Log("Change Sprite");
        ghost.texture = bgGhost[indexImage];
    }
}
