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
    public string[] positiveLabels; // Labels para a resposta positiva ("Sim, me conte mais!")
    public string[] negativeLabels; // Labels para a resposta negativa ("N�o, prefiro ir embora.")

    void Start()
    {
        dialogueLines = new string[]
        {
            "Ola, permita me apresentar me chamo Fasmo o fantasma j� estou aqui nesta mans�o a tanto tempo que ja perdi a no��o do tempo ", // Linha 0 manda pro 2
            "Bem infelizmente fui traido por quem eu mais confiava e acabei preso aqui.", // Linha 1 - manda pro 2 
            "Sim!, por�m para isso ser� necessario que eu conte uma hist�ria", // Linha 2

            "� claro que n�o! a hist�ria � importante, pois voc� tera que responder algumas perguntas que teram haver com ela.", // Linha 3
            "Olha n�o sou eu quem fez as regras, eu apenas as sigo!", // Linha 4
            "Dizem que ele vir� de terras distantes, mas ningu�m sabe exatamente quem �.", // Linha 5
            "Talvez voc� seja o escolhido! Mas, claro, isso � apenas uma hist�ria.", // Linha 6


            "Mas, se preferir, podemos mudar de assunto.", // Linha 7
            "Quem sabe falar sobre os drag�es? Eles s�o criaturas fascinantes.", // Linha 8
            "Os drag�es s�o muito mais inteligentes do que parecem. Alguns dizem que eles falam!", // Linha 9
            "Mas tamb�m h� quem tenha medo deles, claro.", // Linha 10
            "Agora, se preferir, podemos falar sobre os misteriosos portais do Reino.", // Linha 11
            "Esses portais levam a diferentes dimens�es e s�o muito perigosos para aventureiros inexperientes.", // Linha 12
            "Se voc� tiver coragem, posso te contar mais sobre os portais...", // Linha 13

            "Ou, talvez, voc� prefira ir embora e deixar essa conversa para outra hora.", // Linha 14
            "Se for isso que voc� deseja, entendo. Mas quem sabe no futuro?", // Linha 15

            "Oh ok... tudo bem... eu ficarei no aguardo do pr�ximo g�nio que por algum motivo resolveu adentrar em uma mans�o abandonada.", // Linha 16
            "Espero que tenha gostado de ouvir as hist�rias. At� logo!", // Linha 17
            "Obrigado por ouvir as lendas, aventureiro. Fique bem!", // Linha 18
            "Se decidir voltar, estarei aqui para compartilhar mais aventuras.", // Linha 19
        };

        positiveLabels = new string[]
        {
            "Oq voc� faz aqui?",// Linha 0
            "Puxa, que pena, h� alguma forma de voc� ser liberto?",// Linha 1
            "� s� isso?",// Linha 2
            "E como isso vai te libertar exatamente?", // Linha 3
            "Se voc� diz...", // Linha 4
            "Ser� que sou eu? ou � o Luva de pedreiro?", // Linha 5
            "Certeza que sou eu, RECEBAAAA!", // Linha 6
            "J� sei que sou eu mesmo!", // Linha 7
            "Pode ser eu gosto deles", // Linha 8
            "Sim eu assiti o GOT", // Linha 9
            "Quem n�o deve n�o teme par�a", // Linha 10
            "Voc� n�o termina nenhuma hist�ria, chato da peste...", // Linha 11
            "Assisti uma s�rie da cultura que tinha isso ai de portal", // Linha 12
            "Aqui tem coragem, MIAUUU", // Linha 13
            "Voc� � biruleibe? n�o foi isso que falei", // Linha 14
            "Vai tarde", // Linha 15
            "Parece que falei com um doido!", // Linha 16
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
           case 7: // Quando o jogador pergunta sobre os drag�es
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
            case 0: // Primeira linha: "Sim, me conte mais!"
            case 1: // Op��o inicial de saber mais
                int indexImageFeliz = 4;
                ChangeSprite(indexImageFeliz);
                currentLine = 2; // Avan�a para o Reino dos Drag�es
                break;

            case 7: // Quando o jogador escolhe saber mais sobre drag�es
                currentLine = 8; // Fala mais sobre os drag�es
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
        int indexImageBravo = 0;
        ChangeSprite(indexImageBravo);
        currentLine = 16; // Finaliza o di�logo e diz adeus
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
        Debug.Log("Change Sprite");
        ghost.texture = bgGhost[indexImage];
    }
}
