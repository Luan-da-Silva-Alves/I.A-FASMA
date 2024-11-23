using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText; // O texto que será exibido na tela
    public GameObject[] dialogueOptions; // Opções de respostas do diálogo
    public string[] dialogueLines; // As linhas de diálogo
    private int currentLine = 0; // Linha atual do diálogo
    public RawImage ghost;
    public Texture2D[] bgGhost;




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


            "Durante o dia, a mansão permanecia em silêncio absoluto, mas à noite, Fasmo preenchia os cômodos com sons de passos e sussurros. Ele tinha um segredo: em vida, havia sido um músico talentoso, e no salão principal da mansão repousava um velho piano de cauda, onde Fasmo tocava melodias tristes para a lua cheia.", // Linha 7
            "Certo dia, um grupo de jovens corajosos decidiu explorar a mansão, em busca de aventuras e lendas. Ao entrarem, ouviram uma música melancólica ecoando pelos corredores. Intrigados, seguiram o som até o salão principal, onde encontraram Fasmo ao piano..", // Linha 8
            "Para sua surpresa, ele não era um espírito vingativo, mas sim um fantasma amigável, que ansiava por companhia e por alguém que ouvisse suas composições.", // Linha 9
            "A partir daquela noite, a mansão deixou de ser um lugar assustador e tornou-se um refúgio para os jovens, que passaram a se reunir ali para ouvir Fasmo tocar e aprender sobre sua vida misteriosa.\r\n\r\n", // Linha 10
            "Agora,as perguntas.", // Linha 11
            "Qual o segredo de Fasmo?.", // Linha 12
            "Certa resposta", // Linha 13

            "Facil é? certo, por que Fasmo tocava melodias tristes no piano?.", // Linha 14
            "Isso mesmo!", // Linha 15

            "O que motivou os jovens a explorar a mansão?", // Linha 16
            "Espero que tenha gostado de ouvir as histórias. Até logo!", // Linha 17
            "Errou!", // Linha 18
            "Se decidir voltar, estarei aqui para compartilhar mais aventuras.", // Linha 19




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
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora."
                break;
           case 12: // Primeira decisão antes das perguntas
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora."
                break;
            case 14: // Quando o jogador pergunta sobre os portais
                dialogueOptions[0].SetActive(true); // "Sim, me conte mais!"
                dialogueOptions[1].SetActive(true); // "Não, prefiro ir embora."
                break;

            case 16: // Caso o diálogo chegue ao fim
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
            case 0: // "Sim, me conte mais!"
                HandleYesOption();
                break;

            case 1: // "Não, prefiro ir embora."
                HandleNoOption();
                break;
        }

        ShowDialogueLine(); // Atualiza a linha do diálogo
    }

    // Lógica quando o jogador escolhe "Sim, me conte mais!"
    void HandleYesOption()
    {
        switch (currentLine)
        {
            case 0: // Introdução
            case 1: // Opção inicial de saber mais
                int indexImageFeliz = 4;
                ChangeSprite(indexImageFeliz);
                currentLine = 2; // Avança para o Reino dos Dragões
                break;

            case 11: // Quando o jogador escolhe saber mais sobre dragões
                currentLine = 12; // Fala mais sobre os dragões
                break;

            case 14: // Quando o jogador escolhe saber mais sobre os portais
                currentLine = 13; // Fala mais sobre os portais
                break;

            default: // Para todas as outras opções
                currentLine += 1; // Apenas avança para a próxima linha
                int indexImagePadrao = 3;
                ChangeSprite(indexImagePadrao);
                break;
        }
    }

    // Lógica quando o jogador escolhe "Não, prefiro ir embora."
    void HandleNoOption()
    {
        switch (currentLine)
        {
            case 0: // Introdução
            case 12: // Opção inicial de saber mais
                int indexImage = 0;
                ChangeSprite(indexImage);
                currentLine = 18; //texto de erro 
                break;

            case 18: // Quando o jogador escolhe saber mais sobre dragões
                currentLine = 12; // Fala mais sobre os dragões
                break;

            case 14: // Quando o jogador escolhe saber mais sobre os portais
                currentLine = 13; // Fala mais sobre os portais
                break;

            default: // Para todas as outras opções
                currentLine += 1; // Apenas avança para a próxima linha
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
    // Finaliza o diálogo
    void EndDialogue()
    {
        dialogueText.text = "O diálogo terminou. Você pode voltar quando quiser!";
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
}
