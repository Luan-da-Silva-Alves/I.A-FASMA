using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogueSystem : MonoBehaviour
{
    public Text scoreText;
    public Text dialogueText; // O texto que ser� exibido na tela
    public GameObject[] dialogueOptions; // Op��es de respostas do di�logo
    public string[] dialogueLines; // As linhas de di�logo
    private int currentLine = 0; // Linha atual do di�logo
    public RawImage ghost;
    public Texture2D[] bgGhost;
    private int playerScore = 50;
    private const int WinningScore = 150; // Pontua��o para vencer o jogo
    private const int LosingScore = 0; // Pontua��o m�nima antes de perder



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
            
            "Durante o dia, a mans�o permanecia em sil�ncio absoluto, mas � noite, Fasmo preenchia os c�modos com sons de passos e sussurros. Ele tinha um segredo: em vida, havia sido um m�sico talentoso que ningu�m nunca ouviu, e no sal�o principal da mans�o,solitario, repousava um velho piano de cauda, onde Fasmo tocava melodias tristes para a lua cheia.", // Linha 7
            "Depois de anos solatarios fasmo veio a falecer, sozinho ap�s anos de isolamento", //linha 8
            "Certo dia, um grupo de jovens corajosos decidiu explorar a mans�o, em busca de aventuras e lendas. Ao entrarem, ouviram uma m�sica melanc�lica ecoando pelos corredores. Intrigados, seguiram o som at� o sal�o principal, onde encontraram Fasmo ao piano..", // Linha 9
            "Para sua surpresa, ele n�o era um esp�rito vingativo, mas sim um fantasma amig�vel, que ansiava por companhia e por algu�m que ouvisse suas composi��es.", // Linha 10
            "A partir daquela noite, a mans�o deixou de ser um lugar assustador e tornou-se um ref�gio para os jovens, que passaram a se reunir ali para ouvir Fasmo tocar e aprender sobre sua vida misteriosa.\r\n\r\n", // Linha 11
            "Agora,as perguntas.", // Linha 12
            "Qual o segredo de Fasmo?.", // Linha 13 pergunta 1
            "Certa resposta", // Linha 14

            "Facil �? certo, por que Fasmo tocava melodias tristes no piano?.", // Linha 15 pergunta 2
            "Isso mesmo!", // Linha 16

            "O que motivou os jovens a explorar a mans�o?", // Linha 17 pergunta 3
            "Ai sim! voc� est� indo muito bem", // Linha 18
            "Como Fasmo morreu e se tornou um fantasma?", // Linha 19 pergunta 4
            "Algum outro esp�rito habitava a mans�o, ou Fasmo era o �nico?", // Linha 20 pergunta 5
            "Por que Fasmo tocava melodias tristes no piano?",// linha 21 pergunta 6
            "Ta se achando o novo Socrates �?", //linha22
            "Carai borracha..., enfim, como os jovens reagiram ao encontrar Fasmo pela primeira vez?",// linha 23 pergunta 7
            "Isso eu...digo ele nunca faria mal a ningu�m",// linha 24

            "A mans�o tinha outros segredos al�m de Fasmo?",// linha 25 pergunta 8
            "Oque quer dizer com isso?",//linha 26
            "Chata oq? eu n�o sei oq essas palavras significam, GPT? � um tipo de cl� maliguino?",//linha 27
            "Ah, enfim pr�xima pergunta ",//linha 28
            "Havia algo especial ou m�gico no piano de Fasmo?",//29 perunta 9
            "Voc� acha que a  hist�ria de Fasmo inspirou os jovens de alguma maneira?",//linha 30 perunta 10
            "Fasmo tinha alguma liga��o com a constru��o ou o passado da mans�o?",//linha 31 pergunta 11


            //"Voc� errou logo no inicio, s�rio? olha caia fora daqui por favor ", //linha 32 para erro inicio
            //"Esta errado, por�m vou te dar mais uma chance, quer recome�ar as perguntas?",//linha 33 erro meio
            










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
            "Certo", // Linha 10
            "Certo!", // Linha 11
            "Cero,Manda ver!", // Linha 12
            "Ele gostava de tocar piano, por�m ele sempre fez isso sozinho ", // Linha 13
            "Essa foi facil!", // Linha 14
            "Pois ele vivia sozinho", // Linha 15
            "Viva", // Linha 16
            "Eles foram em busca de aventuras e lendas", // Linha 17
            "� claro, eu estava ouvindo a hist�ria", // Linha 18
            "Fasmo morreu de um cora��o partido, sozinho ap�s anos de isolamento,sua forte liga��o emocional com a m�sica ", // Linha 19
            "Ele era o unico",//linha 20
            "As melodias refletiam sua solid�o e arrependimento",//linha 21
            "Nhe nhe nhe, quer que eu te liberte ou n�o?",//linha 22
            "Eles ficaram com medo, por�m depois viram que ele era um fantasma amigavel",//linha 23
            "Certo, certo",//linha 24
            "N�o, voc� n�o falou nada sobre isso, ta delirando?",//linha 25
            "Nada n�o � que at� parece que voc� usou chat gpt para gerar essas perguntas",//linha 26
            "Quase isso...",//linha 27
            "Ok",//linha28
            "N�o, ele um piano comum apenas as musicas eram 'magicas'",//linha 29
            "Com certeza, principalmente a nunca abandonar os amigos, vai que ele � um excelente pianista!",//linha 30
            "Sim, a mans�o era dele pelo que deu a entender",//linha 31
            
            




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
        UpdateScoreText();
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
                dialogueOptions[0].SetActive(true); 
                dialogueOptions[1].SetActive(true); 
                break;
           case 13: // Primeira decis�o antes das perguntas
                dialogueOptions[0].SetActive(true); 
                dialogueOptions[1].SetActive(true); 
                break;
            case 15: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); 
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora."
                break;

            case 17: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 19: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 21: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 23: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 25: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 29: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 30: // Caso o di�logo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "N�o, prefiro ir embora
                break;
            case 31: // Caso o di�logo chegue ao fim
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
            case 0: 
                HandleYesOption();
                UpdateScoreText();
                break;

            case 1: // "N�o, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); // Atualiza a linha do di�logo
        UpdateScoreText();
    }

    // L�gica quando o jogador escolhe "Sim, me conte mais!"
    void HandleYesOption()
    {
        switch (currentLine)
        {
          

            case 13: // P1
                currentLine = 14; 
                UpdateScoreText();
                AddPoints(10);
                int indexImageFeliz = 4;
                ChangeSprite(indexImageFeliz);
                break;

            case 15: //P2
                currentLine = 16; 
                AddPoints(10);
                break;

                case 17: // P3
                currentLine = 18; 
                AddPoints(10);
                break;
            case 19: // P4
                currentLine = 20; // Fala mais sobre os portais
                AddPoints(10);
                break;
            case 20: // P5
                currentLine = 21; // Fala mais sobre os portais
                AddPoints(10);
                int indexImageDesconfiado = 1;
                ChangeSprite(indexImageDesconfiado);

                break;
            case 21: // P5
                currentLine = 22; // Fala mais sobre os portais
                AddPoints(10);
                break;
            case 23: // P6
                currentLine = 24; // Fala mais sobre os portais
                AddPoints(10);
                break;
            case 25: // P8
                currentLine = 26; // Fala mais sobre os portais
                
                break;
            case 27:
                int indexImagePreocupado = 5;
                ChangeSprite(indexImagePreocupado);
                currentLine = 28;
                break;
            case 29: // P9
                currentLine = 30; // Fala mais sobre os portais
                AddPoints(10);
                break;

            case 30: // P10
                currentLine = 31; // Fala mais sobre os portais
                AddPoints(10);
                int indexImageDesconfiado2 = 2;
                ChangeSprite(indexImageDesconfiado2);
                break;
            case 31: // P11
                currentLine = 32; // Fala mais sobre os portais
                AddPoints(10);
                break;

            default: // Para todas as outras op��es
                currentLine += 1; // Apenas avan�a para a pr�xima linha
                int indexImagePadrao = 4;
                ChangeSprite(indexImagePadrao);
                break;
        }

    }

    // L�gica quando o jogador escolhe "N�o, prefiro ir embora."
    void HandleNoOption()
    {
        switch (currentLine)
        {


            case 13: // P1
                currentLine = 32;
                UpdateScoreText();
                SubtractPoints(10);
                EndDialogue();
                DisabledAllOptions();

                break;

            case 15: //P2
                currentLine = 32;
                SubtractPoints(10);
                EndDialogue();
                DisabledAllOptions();
                break;

            case 17: // P3
                currentLine = 32;
                SubtractPoints(10);
                EndDialogue();
                DisabledAllOptions();
                break;
            case 19: // P4
                currentLine = 32; // Fala mais sobre os portais
                EndDialogue();
                DisabledAllOptions();
                SubtractPoints(10);
               
                break;
            case 20: // P5
                currentLine = 33; // Fala mais sobre os portais
                SubtractPoints(10);

                break;
            case 21: // P5
                currentLine = 33; // Fala mais sobre os portais
                SubtractPoints(10);
                break;
            case 23: // P6
                currentLine = 33; // Fala mais sobre os portais
                SubtractPoints(10);
                break;
            case 25: // P8
                currentLine = 34; // Fala mais sobre os portais
                SubtractPoints(10);
                break;
            case 29: // P9
                currentLine = 34; // Fala mais sobre os portais
                SubtractPoints(10);
                break;

            case 30: // P10
                currentLine = 34; // Fala mais sobre os portais
              SubtractPoints(10);
                break;
            case 31: // P11
                currentLine = 34; // Fala mais sobre os portais
                SubtractPoints(10);
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
        dialogueText.text = "Voc� Conseguiu obrigado por me libertar!";
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
    public void UpdateScoreText()
    {
        scoreText.text = "Pontua��o: " + playerScore;
    }
    public void AddPoints(int points)
    {
        playerScore += points;
        UpdateScoreText();
        CheckWinCondition();
    }
    public void SubtractPoints(int points)
    {
        playerScore -= points;
        UpdateScoreText();
        CheckLoseCondition();
    }

    // Verifica se o jogador venceu
    private void CheckWinCondition()
    {
        if (playerScore >= WinningScore)
        {
            GameWin();
            EndDialogue();
            DisabledAllOptions();
        }
    }

    // Verifica se o jogador perdeu
    private void CheckLoseCondition()
    {
        if (playerScore <= LosingScore)
        {
            GameOver();
            EndDialogue();
        }
    }

    // L�gica de vit�ria
    private void GameWin()
    {
        Debug.Log("Voc� venceu o jogo!");
        EndDialogue();
    }

    // L�gica de derrota
    private void GameOver()
    {
        Debug.Log("Voc� perdeu o jogo!");
        // Adicione aqui o que acontecer� quando o jogador perder
    }
}

