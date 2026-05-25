```markdown
# 🪑 Projeto VR – Loja de Hardware

## Loja Virtual Imersiva de Hardware com Interatividade em Realidade Virtual

---

## 📌 Índice

- [Visão Geral](#visão-geral)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Ambiente](#estrutura-do-ambiente)
- [Funcionalidades](#funcionalidades)
- [Interatividade: Cadeira Gamer](#interatividade-cadeira-gamer)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Configuração](#instalação-e-configuração)
- [Como Testar](#como-testar)
- [Controles](#controles)
- [Estrutura de Arquivos](#estrutura-de-arquivos)
- [Próximos Passos](#próximos-passos)
- [Links Importantes](#links-importantes)
- [Créditos](#créditos)

---

## 🎯 Visão Geral

Este projeto consiste no desenvolvimento de um **ambiente imersivo em Realidade Virtual (VR)** utilizando a engine **Unity**, com foco na simulação de uma **loja virtual especializada em equipamentos e componentes de informática**.

O usuário pode explorar livremente a loja em primeira pessoa, visualizar produtos expostos em vitrines virtuais e interagir com elementos do cenário, como a **cadeira gamer animada**, que reage à presença do jogador.

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Finalidade |
|------------|------------|
| **Unity 6 LTS** | Desenvolvimento do ambiente VR |
| **Meta XR SDK** | Recursos de Realidade Virtual e compatibilidade com Quest |
| **XR Plugin Management** | Gerenciamento multiplataforma XR |
| **OpenXR** | Padrão aberto para desenvolvimento VR |
| **Sketchfab** | Fonte dos modelos 3D |
| **C#** | Scripts e funcionalidades interativas |
| **GitHub** | Versionamento do projeto |

---

## 🏗️ Estrutura do Ambiente

O ambiente foi projetado no formato **cúbico**, simulando uma grande loja de informática.

### Componentes da Cena:

| Elemento | Quantidade |
|----------|------------|
| Piso principal texturizado | 1 |
| Paredes estruturais | 3 |
| Mostruários centrais retangulares | 3 |
| Vitrines transparentes | 3 |
| Área gamer temática | 1 |
| Produtos expostos | 28+ |

### Distribuição dos Produtos:

- **Monitores, notebooks e desktops**
- **Teclados mecânicos e controles**
- **Placas de vídeo, memórias RAM e processadores**
- **Roteadores, impressoras 3D e placas-mãe**
- **Componentes eletrônicos diversos**

### Área Gamer:

- Rack para servidores
- Cadeira gamer (com animação interativa)
- Mesa de escritório
- Desktop gamer
- Teclado e monitor gamer

---

## ✨ Funcionalidades

| Funcionalidade | Descrição |
|----------------|-----------|
| **Navegação livre** | Explore a loja caminhando em primeira pessoa |
| **Visualização de produtos** | Observe itens expostos em vitrines e mostruários |
| **Interatividade** | Aproxime-se da cadeira gamer para ativar animação |
| **Compatibilidade XR** | Preparado para Meta Quest via Link Cable ou build nativo |
| **Ambientação imersiva** | Skybox, iluminação dinâmica e materiais realistas |

---

## 🪑 Interatividade: Cadeira Gamer

A cadeira localizada na área gamer reage à presença do jogador:

| Ação do Usuário | Resposta |
|-----------------|----------|
| Aproxima-se | Animação de abertura (gira/desliza) |
| Afasta-se | Animação de fechamento (movimento reverso) |

### Script de Controle (`ChairTrigger.cs`):

```csharp
using UnityEngine;

public class ChairTrigger : MonoBehaviour
{
    private Animator meuAnimator;

    void Start()
    {
        meuAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meuAnimator?.SetBool("isPlayerNear", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meuAnimator?.SetBool("isPlayerNear", false);
        }
    }
}
```

### Configuração do Animator:

| Parâmetro | Tipo | Uso |
|-----------|------|-----|
| `isPlayerNear` | Bool | Controla abertura/fechamento |

**Transições:**

| Origem → Destino | Condição | Has Exit Time |
|------------------|----------|---------------|
| Idle → Chair Open | `isPlayerNear = true` | ❌ OFF |
| Chair Open → Chair Close | `isPlayerNear = false` | ❌ OFF |
| Chair Close → Idle | (sem condição) | ✅ ON (Exit Time: 1) |

---

## 📋 Pré-requisitos

### Para desenvolvimento:

| Item | Especificação |
|------|---------------|
| **Sistema Operacional** | Windows 10/11 64-bit |
| **Unity** | 6 LTS (6000.3.13f1 ou superior) |
| **GPU** | NVIDIA GTX 1060+ ou equivalente |
| **RAM** | 16 GB ou mais |
| **SDK** | Meta XR SDK instalado via Unity Package Manager |

### Para teste em headset (opcional):

| Item | Especificação |
|------|---------------|
| **Headset** | Meta Quest 2, 3 ou Pro |
| **Cabo** | USB-C de alta velocidade (para Link Cable) |
| **Conta** | Meta Developer account ativada |

---

## 🔧 Instalação e Configuração

### 1. Clonar o repositório

```bash
git clone https://github.com/Eng-Wangles/Projeto-VR-Wangles.git
cd Projeto-VR-Wangles
```

### 2. Abrir no Unity

- Abra o **Unity Hub**
- Clique em **"Open Project"** → Selecione a pasta clonada
- Aguarde a importação dos assets e pacotes

### 3. Configurar XR

1. **Edit → Project Settings → XR Plug-in Management**
2. Marque **OpenXR** para a plataforma desejada (Windows/Android)
3. Certifique-se de que **Meta XR** está listado

### 4. Configurar qualidade (opcional)

```
Edit → Project Settings → Quality
├─ Texture Quality: Full Res
├─ Anti Aliasing: 4x
└─ Master Texture Limit: No Limit
```

### 5. Verificar a tag do player

1. Selecione `[BuildingBlock] Camera Rig` na Hierarchy
2. No Inspector, configure **Tag → Player**
3. Crie a tag "Player" se necessário

---

## 🎮 Como Testar

### Opção 1: No Editor (teclado e mouse)

1. Clique em **Play (►)**
2. Use as teclas **WASD** para movimentação
3. Aproxime-se da cadeira gamer para testar a animação

### Opção 2: Meta Quest Link Cable (recomendado)

1. Conecte o Quest ao PC via cabo USB-C
2. Ative **Quest Link** no headset
3. No PC, abra o **Meta Horizon Link** e defina como OpenXR Runtime
4. No Unity, clique em **Play (►)**
5. Coloque o headset e teste em tempo real

### Opção 3: Build para Android/Quest

```
File → Build Settings
├─ Platform: Android
├─ Run Device: Seu Quest
└─ Build and Run
```

---

## 🎮 Controles

### Navegação no Editor (teclado/mouse):

| Tecla | Ação |
|-------|------|
| `WASD` | Movimentação |
| `Mouse` | Olhar ao redor |

### Interação:

| Ação | Resultado |
|------|-----------|
| Aproximar-se da cadeira | Animação de abertura |
| Afastar-se da cadeira | Animação de fechamento |

---

## 📂 Estrutura de Arquivos

```
Projeto-VR-Wangles/
├── Assets/
│   ├── Animation/
│   │   ├── Chair Open.anim
│   │   ├── Chair Close.anim
│   │   └── GameChair Animation.controller
│   ├── Scripts/
│   │   └── ChairTrigger.cs
│   ├── Models/
│   │   ├── GameChair.fbx
│   │   └── ... (demais assets 3D)
│   ├── Materials/
│   ├── Textures/
│   └── Scenes/
│       └── Oficina de Hardware.unity
├── ProjectSettings/
├── Packages/
└── README.md
```

---

## 🚀 Próximos Passos

- [ ] Adicionar efeitos sonoros à animação da cadeira
- [ ] Criar UI interativa com informações dos produtos
- [ ] Adicionar multiplayer para visitação simultânea
- [ ] Implementar sistema de compras virtual
- [ ] Otimizar performance para mais assets

---

## 🔗 Links Importantes

| Link | Descrição |
|------|-----------|
| [GitHub do Projeto](https://github.com/Eng-Wangles/Projeto-VR-Wangles) | Repositório principal |
| [Vídeo Demonstrativo](https://youtu.be/tQoa-xMJDg0) | Demonstração da loja virtual |


### Documentações de referência:

- [Unity Documentation](https://docs.unity3d.com/)
- [Meta XR SDK Documentation](https://developer.oculus.com/documentation/unity/)
- [Sketchfab](https://sketchfab.com/)
- [Unity Learn](https://learn.unity.com/)
- [Meta Developers](https://developer.oculus.com/)

---

## 👨‍💻 Autor

**Wangles Moreira Soares**

- 📧 soares.wangles@gmail.com

---

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais e de demonstração de conceitos de Realidade Virtual.

---

## 🙏 Créditos

- Modelos 3D disponibilizados por criadores no [Sketchfab](https://sketchfab.com/)
- Meta XR SDK por viabilizar o desenvolvimento VR
- Unity por fornecer a plataforma de desenvolvimento

---

## ⭐ Agradecimentos

Agradeço a todos os professore(a)s, mentore(a)s e orientadore(a)s do curso WEB 3.0 Metaverso!

Feedbacks e contribuições são sempre bem-vindos.

---

**Versão:** 1.1  
**Última atualização:** 25/05/2026
```
