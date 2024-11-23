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
    public string[] positiveLabels; // Labels para a resposta positiva ("Sim, me conte mais!")
    public string[] negativeLabels; // Labels para a resposta negativa ("Não, prefiro ir embora.")

    void Start()
    {
        dialogueLines = new string[]
        {
            "Ola, permita me apresentar me chamo Fasmo o fantasma já estou aqui nesta mansão a tanto tempo que ja perdi a noção do tempo ", // Linha 0 manda pro 2
            "Bem infelizmente fui traido por quem eu mais confiava e acabei preso aqui.", // Linha 1 - manda pro 2 
            "Sim!, porém para isso será necessario que eu conte uma história", // Linha 2

            "É claro que não! a história é importante, pois você tera que responder algumas perguntas que teram haver com ela.", // Linha 3
            "Olha não sou eu quem fez as regras, eu apenas as sigo!", // Linha 4
            "Dizem que ele virá de terras distantes, mas ninguém sabe exatamente quem é.", // Linha 5
            "Talvez você seja o escolhido! Mas, claro, isso é apenas uma história.", // Linha 6


            "Mas, se preferir, podemos mudar de assunto.", // Linha 7
            "Quem sabe falar sobre os dragões? Eles são criaturas fascinantes.", // Linha 8
            "Os dragões são muito mais inteligentes do que parecem. Alguns dizem que eles falam!", // Linha 9
            "Mas também há quem tenha medo deles, claro.", // Linha 10
            "Agora, se preferir, podemos falar sobre os misteriosos portais do Reino.", // Linha 11
            "Esses portais levam a diferentes dimensões e são muito perigosos para aventureiros inexperientes.", // Linha 12
            "Se você tiver coragem, posso te contar mais sobre os portais...", // Linha 13

            "Ou, talvez, você prefira ir embora e deixar essa conversa para outra hora.", // Linha 14
            "Se for isso que você deseja, entendo. Mas quem sabe no futuro?", // Linha 15

            "Oh ok... tudo bem... eu ficarei no aguardo do próximo gênio que por algum motivo resolveu adentrar em uma mansão abandonada.", // Linha 16
            "Espero que tenha gostado de ouvir as histórias. Até logo!", // Linha 17
            "Obrigado por ouvir as lendas, aventureiro. Fique bem!", // Linha 18
            "Se decidir voltar, estarei aqui para compartilhar mais aventuras.", // Linha 19
        };

        positiveLabels = new string[]
        {
            "Oq você faz aqui?",// Linha 0
            "Puxa, que pena, há alguma forma de você ser liberto?",// Linha 1
            "É só isso?",// Linha 2
            "E como isso vai te libertar exatamente?", // Linha 3
            "Se você diz...", // Linha 4
            "Será que sou eu? ou é o Luva de pedreiro?", // Linha 5
            "Certeza que sou eu, RECEBAAAA!", // Linha 6
            "Já sei que sou eu mesmo!", // Linha 7
            "Pode ser eu gosto deles", // Linha 8
            "Sim eu assiti o GOT", // Linha 9
            "Quem não deve não teme parça", // Linha 10
            "Você não termina nenhuma história, chato da peste...", // Linha 11
            "Assisti uma série da cultura que tinha isso ai de portal", // Linha 12
            "Aqui tem coragem, MIAUUU", // Linha 13
            "Você é biruleibe? não foi isso que falei", // Linha 14
            "Vai tarde", // Linha 15
            "Parece que falei com um doido!", // Linha 16
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
           case 7: // Quando o jogador pergunta sobre os dragões
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
            case 0: // Primeira linha: "Sim, me conte mais!"
            case 1: // Opção inicial de saber mais
                int indexImageFeliz = 4;
                ChangeSprite(indexImageFeliz);
                currentLine = 2; // Avança para o Reino dos Dragões
                break;

            case 7: // Quando o jogador escolhe saber mais sobre dragões
                currentLine = 8; // Fala mais sobre os dragões
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
        int indexImageBravo = 0;
        ChangeSprite(indexImageBravo);
        currentLine = 16; // Finaliza o diálogo e diz adeus
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
        Debug.Log("Change Sprite");
        ghost.texture = bgGhost[indexImage];
    }
}
