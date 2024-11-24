using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogueSystem : MonoBehaviour
{
    public Text scoreText;
    public Text dialogueText; // O texto que será exibido na tela
    public GameObject[] dialogueOptions; // Opções de respostas do diálogo
    public string[] dialogueLines; // As linhas de diálogo
    private int currentLine = 0; // Linha atual do diálogo
    public RawImage ghost;
    public Texture2D[] bgGhost;
    private int playerScore = 50;
    private const int WinningScore = 150; // Pontuação para vencer o jogo
    private const int LosingScore = 0; // Pontuação mínima antes de perder



    // Listas de labels para os botões
    public string[] positiveLabels; // Labels para a resposta positiva 
    public string[] negativeLabels; // Labels para a resposta negativa 

    void Start()
    {
        dialogueLines = new string[]
        {
            "Ola, permita me apresentar me chamo Fasmo o fantasma já estou aqui nesta mansão a tanto tempo que ja perdi a noção do tempo ", // Linha 0 manda pro 2
            "Bem infelizmente fui traido por quem eu mais confiava e acabei preso aqui.", // Linha 1 - manda pro 2 
            "Bem infelizmente fui traido por quem eu mais confiava e acabei preso aqui.", // Linha 2

            "Bem, para você me libertar, antes disso é necessario que eu te conte uma história", // Linha 3
            "É claro que não! a história é importante, pois você tera que responder algumas perguntas que teram haver com ela.", // Linha 4
            "Olha não sou eu que faz as regras eu apenas as sigo.", // Linha 5
            "Á muito tempo, no alto de uma colina cercada por neblina constante, existia uma mansão antiga, habitada apenas por um espírito conhecido como Fasmo. Ele era um fantasma solitário, vagando pelos corredores empoeirados e ouvindo os ecos de uma vida que já não existia.", // Linha 6
            
            "Durante o dia, a mansão permanecia em silêncio absoluto, mas à noite, Fasmo preenchia os cômodos com sons de passos e sussurros. Ele tinha um segredo: em vida, havia sido um músico talentoso que ninguém nunca ouviu, e no salão principal da mansão,solitario, repousava um velho piano de cauda, onde Fasmo tocava melodias tristes para a lua cheia.", // Linha 7
            "Depois de anos solatarios fasmo veio a falecer, sozinho após anos de isolamento", //linha 8
            "Certo dia, um grupo de jovens corajosos decidiu explorar a mansão, em busca de aventuras e lendas. Ao entrarem, ouviram uma música melancólica ecoando pelos corredores. Intrigados, seguiram o som até o salão principal, onde encontraram Fasmo ao piano..", // Linha 9
            "Para sua surpresa, ele não era um espírito vingativo, mas sim um fantasma amigável, que ansiava por companhia e por alguém que ouvisse suas composições.", // Linha 10
            "A partir daquela noite, a mansão deixou de ser um lugar assustador e tornou-se um refúgio para os jovens, que passaram a se reunir ali para ouvir Fasmo tocar e aprender sobre sua vida misteriosa.\r\n\r\n", // Linha 11
            "Agora,as perguntas.", // Linha 12
            "Qual o segredo de Fasmo?.", // Linha 13 pergunta 1
            "Certa resposta", // Linha 14

            "Facil é? certo, por que Fasmo tocava melodias tristes no piano?.", // Linha 15 pergunta 2
            "Isso mesmo!", // Linha 16

            "O que motivou os jovens a explorar a mansão?", // Linha 17 pergunta 3
            "Ai sim! você está indo muito bem", // Linha 18
            "Como Fasmo morreu e se tornou um fantasma?", // Linha 19 pergunta 4
            "Algum outro espírito habitava a mansão, ou Fasmo era o único?", // Linha 20 pergunta 5
            "Por que Fasmo tocava melodias tristes no piano?",// linha 21 pergunta 6
            "Ta se achando o novo Socrates é?", //linha22
            "Carai borracha..., enfim, como os jovens reagiram ao encontrar Fasmo pela primeira vez?",// linha 23 pergunta 7
            "Isso eu...digo ele nunca faria mal a ninguém",// linha 24

            "A mansão tinha outros segredos além de Fasmo?",// linha 25 pergunta 8
            "Oque quer dizer com isso?",//linha 26
            "Chata oq? eu não sei oq essas palavras significam, GPT? é um tipo de clã maliguino?",//linha 27
            "Ah, enfim próxima pergunta ",//linha 28
            "Havia algo especial ou mágico no piano de Fasmo?",//29 perunta 9
            "Você acha que a  história de Fasmo inspirou os jovens de alguma maneira?",//linha 30 perunta 10
            "Fasmo tinha alguma ligação com a construção ou o passado da mansão?",//linha 31 pergunta 11


            //"Você errou logo no inicio, sério? olha caia fora daqui por favor ", //linha 32 para erro inicio
            //"Esta errado, porém vou te dar mais uma chance, quer recomeçar as perguntas?",//linha 33 erro meio
            










        };

        positiveLabels = new string[]
        {
            "Oq você faz aqui?",// Linha 0
            "Puxa, que pena, há alguma forma de você ser liberto?",// Linha 1
            "Puxa, que pena, há alguma forma de você ser liberto?",// Linha 2
            "Só isso?", // Linha 3
            "Se você diz...", // Linha 4
            "Certo, qual a história?", // Linha 5
            "Certo, e depois?", // Linha 6
            "Certo", // Linha 7
            "Ok...", // Linha 8
            "Hum...", // Linha 9
            "Certo", // Linha 10
            "Certo!", // Linha 11
            "Cero,Manda ver!", // Linha 12
            "Ele gostava de tocar piano, porém ele sempre fez isso sozinho ", // Linha 13
            "Essa foi facil!", // Linha 14
            "Pois ele vivia sozinho", // Linha 15
            "Viva", // Linha 16
            "Eles foram em busca de aventuras e lendas", // Linha 17
            "É claro, eu estava ouvindo a história", // Linha 18
            "Fasmo morreu de um coração partido, sozinho após anos de isolamento,sua forte ligação emocional com a música ", // Linha 19
            "Ele era o unico",//linha 20
            "As melodias refletiam sua solidão e arrependimento",//linha 21
            "Nhe nhe nhe, quer que eu te liberte ou não?",//linha 22
            "Eles ficaram com medo, porém depois viram que ele era um fantasma amigavel",//linha 23
            "Certo, certo",//linha 24
            "Não, você não falou nada sobre isso, ta delirando?",//linha 25
            "Nada não é que até parece que você usou chat gpt para gerar essas perguntas",//linha 26
            "Quase isso...",//linha 27
            "Ok",//linha28
            "Não, ele um piano comum apenas as musicas eram 'magicas'",//linha 29
            "Com certeza, principalmente a nunca abandonar os amigos, vai que ele é um excelente pianista!",//linha 30
            "Sim, a mansão era dele pelo que deu a entender",//linha 31
            
            




        };

        negativeLabels = new string[] {

            "Oq você faz aqui?",// Linha 0
            "Puxa, que pena, há alguma forma de você ser liberto?",// Linha 1
            "Puxa, que pena, há alguma forma de você ser liberto?",// Linha 2
            "Só isso?", // Linha 3
            "Se você diz...", // Linha 4
            "Certo, qual a história?", // Linha 5
            "Certo, e depois?", // Linha 6
            "Certo", // Linha 7
            "Ok...", // Linha 8
            "Hum...", // Linha 9
            "Certo!", // Linha 10
            "Cero,Manda ver!", // Linha 11
            "Ele gostava de tocar piano, porém ele sempre fez isso sozinho ", // Linha 12
            "Essa foi facil!", // Linha 13
            "Pois ele vivia sozinho", // Linha 14
            "Vai tarde", // Linha 15
            "Até mais!", // Linha 16
            "Que nada, só fazer um pix de R$100", // Linha 17
            "Até breve biruta", // Linha 17

        };

        // Exibe a primeira linha do diálogo
        ShowDialogueLine();
        UpdateScoreText();
    }

    // Exibe uma linha de diálogo
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

    // Desativa todas as opções
    void DisabledAllOptions()
    {
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false);
        }
    }

    // Exibe as opções de resposta
    void ShowOptions()
    {

        // Exibe opções com base na linha atual
        switch (currentLine)
        {
            case 0: // Primeira linha de diálogo
            case 1:
                dialogueOptions[0].SetActive(true); 
                dialogueOptions[1].SetActive(true); 
                break;
           case 13: // Primeira decisão antes das perguntas
                dialogueOptions[0].SetActive(true); 
                dialogueOptions[1].SetActive(true); 
                break;
            case 15: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); 
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora."
                break;

            case 17: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 19: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 21: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 23: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 25: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 29: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 30: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            case 31: // Caso o diálogo chegue ao fim
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora
                break;
            default: // Para todas as outras opções
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(false); // "Não, prefiro ir embora
                break;
        }
    }

    // Função para o jogador selecionar uma resposta
    public void SelectOption(int optionIndex)
    {
        switch (optionIndex)
        {
            case 0: 
                HandleYesOption();
                UpdateScoreText();
                break;

            case 1: // "Não, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); // Atualiza a linha do diálogo
        UpdateScoreText();
    }

    // Lógica quando o jogador escolhe "Sim, me conte mais!"
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

            default: // Para todas as outras opções
                currentLine += 1; // Apenas avança para a próxima linha
                int indexImagePadrao = 4;
                ChangeSprite(indexImagePadrao);
                break;
        }

    }

    // Lógica quando o jogador escolhe "Não, prefiro ir embora."
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
    // Finaliza o diálogo
    void EndDialogue()
    {
        dialogueText.text = "Você Conseguiu obrigado por me libertar!";
        foreach (GameObject option in dialogueOptions)
        {
            option.SetActive(false); // Aqui os botões são desativados quando o diálogo termina
        }
    }
    public void ChangeSprite(int indexImage)
    {
        //Debug.Log("Change Sprite");
        ghost.texture = bgGhost[indexImage];
    }
    public void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + playerScore;
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

    // Lógica de vitória
    private void GameWin()
    {
        Debug.Log("Você venceu o jogo!");
        EndDialogue();
    }

    // Lógica de derrota
    private void GameOver()
    {
        Debug.Log("Você perdeu o jogo!");
        // Adicione aqui o que acontecerá quando o jogador perder
    }
}

