# 개정이력

|  날짜  | 내용  | 담당자   | 검수자  | 
|---|---|---|---|
|  2018년 7월 21일 | 검증된 빌드 환경 내용 추가  | 김석환  |  사용자  |
|  2018년 7월 26일 | SDK 주의 #1 수정  | 김석환  |  사용자  |
|  2018년 7월 27일 | How to customize 추가  | 김석환  |  사용자  |
|  2018년 7월 27일 | SATES 소개 추가  | 김석환  |  사용자  |
|  2018년 8월 1일 | SATES 로 가능한 일 추가  | 김석환  |  사용자  |

# SATES 소개
## SATES (Spec And Test Engineering System) 란?
SATES 는 제목 그대로 Spec And Test Engineering System 의 약자이다. 사양서 및 테스트 케이스를 문서화하고, 테스트코드를 실행하며 이 결과를 다시 문서에 반영하는 등의 과정을 자동화하는 시스템이다. 

SATES 는 아래 보이는 V-Model 의 문서화 지원을 목적으로 한다.

![Alt text](https://github.com/seokhwan/sates/trunk/docs/readme_img/vmodel_img.png "V Model 개념도, 출처 : https://en.wikipedia.org/wiki/V-Model_(software_development)")


구체적으로 

- SPEC, 테스트 케이스, 테스트 코드, Source 코드 간의 맵핑
- 맵핑된 문서의 생성 

을 목표로 한다.

## SATES 로 가능한 일
- Doxygen 형식의 SPEC, 테스트 케이스 등 문서 작성 후 생성
- CSharp, C/C++(개발 필요) 유닛 테스트
- SPEC, 테스트 케이스, 테스트 코드, Source 코드 간의 맵핑 문서 생성

## SATES 개발 배경
### 개인적 목적
SATES 를 개발하게된 동기는 다분히 내가 사용하기 위해서이다. 입사 후, 회사에서 본격적으로 소프트웨어 개발을 본업으로 시작하게 되었다. 본래 프로그래밍을 좋아하였고, 또, 신뢰성있는 소스코드를 작성하는 것에 흥미를 느꼈기 때문에 수 많은 문서화에 대해 거부감은 없었다. 다만, 문서화 툴이 너무 부족하다는 것을 많이 느꼈다.

사실 세상에는 수 많은 (아주 전문적인) 문서화 툴이 존재한다. 하지만, 개인적으로 개발자는 문서작성과 소스코드 작성 및 디버깅 활동을 하나의 에디터에서 할 수 있어야 한다고 생각한다. 필자도 개발자 이지만, 개발자란 무척이나 게으르며 또한 개발관련 이외의 배움에 있어 무척 배타적이다. (그렇지 않은 개발자들에게는 미안하다.) 예를 들어, 회사에 아무리 좋은 IBM Doors 와 같은 요구사항관리 시스템을 구비해 놓아도, 개발자들에게 이를 사용하기 위해, 무거운 SW 를 실행해야 한다거나 혹은 어떤 웹에 접속하여 로그인할 것 등을 요구하면 개발자들은 면전에서는 알았다고 대답할지 모르겠으나, 실제 코딩을 하면서 이를 동시에 실행하지는 않는다. (명심하자. SW 문서화는 코딩과 동시에 진행하지 않으면 안된다.) 또한, IBM Doors 를 배우기 위해 몇 시간 강의를 들을 것을 강요하면, 참석은 하겠지만 참석하여 핸드폰을 보거나 다른 프로그래밍 관련 서적을 가져와 읽을 것이다. 적어도 나는 그러했다. 

그래서 SATES 를 만들게 되었다. 모든 문서는 doxygen 과 같은 형식의 텍스트 파일로 작성하고 소스코드 내부에 문서와 소스코드 파일명 등의 링크를 편집해주면 이를 모두 머징하여 하나의 문서로 만들어주는 시스템 (즉, SATES) 을 만들게 되었다. 

이 툴을 활용하여 나는 복잡한 전문툴킷을 활용하지 않더라도, 

- <strong>소스코드, 사양서, 테스트케이스, 테스트 코드 를 모두 맵핑한 문서</strong>
 
을 가질 수 있기를 기대한다.

### 공개를 위한 목적
나는 이 프로젝트를 공개하고자 한다. 나는 우리나라의 개발자들이 문서화에 좀 더 호의적이고, 문서화를 잘했으면 한다. 그리고, 이는 궁극적으로 우리나라 SW가 조금 더 발전하는 개기가 될 것이고, 그렇게되면 나와 같은 개발자들에게 조금 더 좋은 환경이 될 것이라고 기대한다. 이것이 이 프로젝트를 공개하는 하나의 이유이고, 그것 자체가 하나의 목적이다. 

회사에 근무하면서 생각보다 많은 개발자들이 문서화를 극도로 혐오하고, 또한 문서 작성에 대한 기본이 전혀 되어 있지 않음을 알 수 있었다. 이것은 나이의 많고 적음 그리고 직급의 높고 낮음에 관계없이 수 많은 개발자들에게 이러한 면을 볼 수 있었다. 소프트웨어 관련 전공을 하는 경우, 학부 1학년 때부터 SW 의 문서화는 무척 중요하다는 말을 귀에 못이 박히도록 듣는다. 그럼에도 SW 문서화를 극도로 혐오하고 문서화의 유용함을 전혀 모르는 개발자들이 양성되고 있는 것이 현실이다.

왜 그러할까? 이에 대한 대표적인 이유는,

첫째, 경험의 부족이다. 문서화에 대해 거부감을 가지고 있는 개발자들을 보면 대부분 개발의 경험이 그렇게 풍부하지는 않다. 여기서 말하는 개발 경험의 풍부함이란 어떤 소프트웨어를 처음부터 작성하여 수 년간 유지보수를 하는 경험을 의미한다. 아무리 천재의 개발자라고 하더라도 본인이 3년전에 작성한 코드를 정확히 기억할 수는 없다. 3년전에 작성한 코드에 문제가 발생하여 갑자기 수정이 필요할 때, 그에게 절대적으로 필요한 것은 그 당시에 작성한 문서이다. 그 문서는 당신의 시간을 절약해준다. 그러한 경험이 없는 개발자는 문서화를 거부할 수 밖에 없다.

둘째, 역시 경험의 부족이다. "개발자는 코드로 이야기한다" 라는 아름다운 말을 마치 "개발자는 코드만 잘짜면 땡이다." 라는 말로 곡해하는 개발자들이 있다. "개발자는 코드로 이야기한다." 라고 말을하며, 어떤 문서화도 하지 않는 행위가 인정받기 위해서는 당신이 작성한 코드가 그 어떤 누구도 불만을 재기할 수 없을 만큼 완벽히 동작해야 한다. 그런데, 여기서 완벽히 동작하는 것을 증명하는데 문서가 필요하다. 아이러니이다. 실제 실무에서는 품질담당자, 상품기획담당자와 대화하는 경우가 많은데, 이들은 당신이 작성한 코드의 이해관계자 (stakeholder) 이며, (명심하자. 당신이 코드를 작성한 코드는 이해관계자가 만족할 때 의미가 있다.) 이들은 전혀 코드를 이해하지 못한다. 이들은 오로지 자연어로 작성된 문서만을 이해한다. (심지어 가끔은 자연어 조차도 이해하지 못하는 경우가 허다하다.) 품질에 문제를 재기하는 품질담당자에게 개발자는 잘 정리된 사양서, 테스트케이스, 테스트결과서, 소스코드 를 제출한다. 제품의 기능 / 사양적 측면에 문제를 재기하는 상품기획담당자에게 개발자는 사양서를 제출한다. 당신은 코드로 이야기하고 싶을지 모르나, 실제로는 코드로 대화하는 것이 아니라, 문서로 대화하는 것이다. 이러한 경험이 없는 개발자는 문서화를 필요없는 일로 치부한다. 코드는 중요하다. 그런데, 당신이 작성한 귀중한 코드는 문서를 통해 외부와 대화한다. 명심하자.

셋째, 좋은 예제를 본적이 없다. 필자가 생각할 때, 현실적으로 이것이 가장 큰 이유이다. SW 의 문서화는 무척중요하다. 라는 말을 무척 많이 하지만, 실제 학생 시절에 제대로 문서화가된 소스코드 및 문서를 본적이 있는가? 솔직히 말하면 나는 없다. 실제 오픈소스는 그렇게 문서화가 회사에서 작성하는 상용소스코드처럼 자세하지는 않다. 기본적으로 오픈소스는 불특정 다수가 자발적으로 개발하기 때문에 (실제는 특정소수가 대부분이지만) 이들에게 문서화를 강제할 수 없다. 사실 첫째, 둘째에 해당하지 않는 개발자들 (즉, 회사에서 일할 때에는 제대로 문서화를 하는 개발자) 역시 오픈소스와 같은 본업이 아닌 코드를 작성할 때, 성실히 문서화를 하지는 않는다. 따라서, 오픈소스에서 제대로 된 문서화를 보기는 어렵다. 그리고, 상용소스코드는 당연히 유료이기 때문에 학생 시절에 그러한 코드를 보는 것은 어렵다. 아이러니하다. 우리는 SW의 문서화를 강조하면서 좋은 예가 없는 환경에 놓여진 것이다. 

나는 이 프로젝트가 하나의 참고할만한 좋은 예가 되었으면 한다.

## SATES 문서 읽는 법
### 도입
SW 문서를 읽는 것을 마치 교과서처럼 읽으면서 무엇인가 쉽게 배울 수 있을 것이라고 기대하는 사람들이 있다. SW 문서가 그렇게 작성된다면 더할 나위가 없을 것이다. 그렇게 문서를 작성하면 좋겠지만, 나는 그러한 능력은 없는 것 같다. 따라서, SATES 의 문서는 무척 딱딱하다. 여러분의 양해를 바란다. 

SW 문서에서 문서의 읽음이 쉬운 것보다 더욱 중요한 것은 문서의 내용에 오해가 없도록 작성되는 것이다. SW 문서는 프로그래밍 언어와 같아야 한다. (Context Free Grammar) 즉, 최대한 누가 읽어도 오해가 없도록 중의적 표현이 없어야 하며 또한 모든 내용은 검증가능한 (testable) 한 표현으로 작성되어, 해당 내용의 만족 혹은 불만족의 판정이 명쾌할 수 있도록 작성되어야 한다. 

### V-Model 의 흐름
앞서, SATES 는 V-Model 의 문서화 지원을 목표로 한다고 명기하였다. SATES 의 docs 의 directory 구조는 아래 그림과 같다. Directory Tree 구조는 항상 아름답다.

```
├── FMEA
├── SPEC
│   ├── S01_BIZ_REQ
│   ├── S02_SRS
│   │   ├── R01_USECASE
│   │   ├── R02_FUNCTIONAL
│   │   └── R03_NON_FUNCTIONAL
│   └── S03_SW_DESIGN
│       ├── D01_STATIC_VIEW
│       └── D02_DYNAMIC_VIEW
├── TESTCASE
│   ├── T01_ACCEPTANCE
│   ├── T02_INTEGRATION
│   └── T03_UNIT
```

크게 FMEA, SPEC, TESTCASE 디렉토리가 가장 상위에 위치하고 있다. 현재 FMEA 는 지원하지 않는다. (2018년 7월 27일) SPEC 은 내부적으로 S01_BIZ_REQ, SRS (Software Requirements Specification), SW (Software) Design 디렉토리가 있다.

#### S01_BIZ_REQ
비즈니스 요구사항은 사실 일반적으로 개발자들에게 쉽게 다가서지 않는 개념이다. 그리고, 사실 실무 개발자가 실제 작성할 일은 극히 드물다고 할 수 있다. 하지만, 이는 실제 개발업무에 있어서는 생각보다 매우 중요하다. 일단, 왜 중요한지에 대해 명확히 하고자 한다. 그렇지 않으면, 이 항목의 존재의 이유가 없다. 당위성이 없는 항목은 작성할 필요가 없는 항목이다.

일반적으로 회사에서 비즈니스 애널리스트 (BA: Business Analyst) 들이 바로 비즈니스 요구사항을 도출하는데, 이 비즈니스 요구사항이란 해당 소프트웨어 프로젝트를 통해 이루고자 하는 비즈니스 관점의 최상위 관심사항 (concern) 이라고 할 수 있다. 가령, 은행시스템의 프로젝트인 경우, "창구의 혼잡도를 30% 감소시켜 고객만족도를 50% 향상시킨다." 가 비즈니스적 요구사항일 수 있다. 아주 솔직하고 정확히 이야기해보자. 우리에게 프로젝트 개발을 발주하신 고객님은 우리가 그렇게 소중하게 생각하는 소스코드에 관심은 1도 없다 (소프트웨어 개발 자체가 목적인 프로젝트는 제외) 고객은 철저히 비즈니스 요구사항에 관심이 있다. 

그런데, 개발자들이 간과하는 것 중 하나가 소프트웨어 개발은 SRS 를 만족시키는 것이라고 오해하는 것이다. 물론 최말단의 실무개발자에게는 그 이상을 아무도 요구하지 않기 때문에, 그러한 자세만으로 크게 무리가 없을 수 있다. 하지만, 깨달아야 한다. 우리의 목표는 SRS가 아닌 비즈니스 요구사항의 만족이다. 아무리 SRS 를 100% 만족시키는 소스코드를 개발한다 할지라도 고객의 비즈니스적 요구를 충족시키지 못한다면, 그 프로젝트는 100% 실패한 프로젝트로 판명될 것이고, 당신은 실패한 프로젝트수행이란 좋지 않은 이력이 당신의 이력서에 남을 것이다.

예를 들어보자. 은행시스템에서 고객만족도 향상 이라는 비즈니스 요구와 또 다른 비용절감 이라는 비즈니스 요구가 있다고 하자. 당신이 어떤 부분의 소스코드를 작성하는데, 두 가지의 선택이 있다. 하나는 비효율적으로 메모리를 매우 많이 사용하지만 속도가 무척 빠른 라이브러리 A 가 있고, 또다른 메모리는 매우 적게 효율적으로 사용하지만 속도가 꽤 느린 라이브러리 B 가 있다고 가정하자. 비즈니스 요구사항이 "고객만족도 향상" 이라면, 당신은 A 를 선택해야한다. 만약 "비용절감" 이 비즈니스 요구사항이라면 B를 선택해야한다 (HW 비용이 줄어들 확률이 높다) SRS, 설계에서 이런 부분까지 모두 상세하는 것은 사실 불가능하다. 이렇듯 비즈니스 요구사항은 상세되지 않고 모호한 결정을 할 때, 꼭 참조해야 하는 최상위 요구사항이다. 

이러한 원칙은 사실 SRS, 소프트웨어 설계에도 모두 적용이 된다. 예를 들어, 비용절감이 우선인 프로젝트의 경우 가용한 HW 의 가격에 맞추어 가용한 CPU 및 메모리 자원의 한계가 SRS에 명기될 것이고, 시스템은 그 자원내에서 동작하게끔 설계되어야 할 것이다. 예를 들어, 모든 통신을 텍스트 기반의 메시지형태로 주고 받는 아주 커플링이 낮은 시스템 설계 보다는 유지보수성은 좋지 않지만 성능에 유리한 운영체제의 바이너리 인터페이스 (즉, dll 혹은 so 파일) 를 활용하는 상세설계가 주어질 것이다. 

#### S02_SRS
- 작성 필요

#### S03_SW_DESIGN
- 작성 필요

### TESTCASE
- 작성 필요
#### T01_ACCEPTANCE
- 작성 필요
#### T02_INTEGRATION
- 작성 필요
#### T03_UNIT
- 작성 필요

# How to run
## svn / github checkout

## 코드 편집
./code/test_sates_core/Program.cs 파일의 const string DEFAULT_PATH 스트링 편집

# How to customize
## Doxygen 태그 추가
./resource/doxy/sates_doxy 파일의 55번째 줄에서 시작하는 ALIASES 을 편집한다.



# 빌드환경
## Microsoft Windows

마지막 검증 일자 :  2018 년 7월 26일

| 항목 | 버전 |
|------|-----|
| 버전 |  Windows 10  [Version 10.0.17134.167] |
| IDE | Microsoft Visual Studio Express 2017 for Windows Desktop 15.7.5 |
| C/C++ Compiler | Microsoft (R) C/C++ Optimizing Compiler Version 19.14.26433 for x86 |
| C# Compiler | Microsoft (R) Visual C# Compiler version 2.8.3.63029 (e9a3a6c0) |


### Dependencies 
- doxygen 1.8.14 <br>
https://sourceforge.net/projects/doxygen/
- graphviz 2.38 <br>
https://graphviz.gitlab.io/download/
- Plantuml v1.2018.8 <br>
http://plantuml.com/
- jdk 8u172 <br>
http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html
- .NET Core SDK x64 (v2.1.302) <br>
https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.302-windows-x64-installer

## 주의
### .NET Core SDK 버전 (2018년 7월 26일)
.NET Core SDK 의 버전명은 정확히 이해하기 어렵다. <br>
예를 들어, https://www.microsoft.com/net/download/dotnet-core/2.0 <br>
페이지를 보면, v2.0.9 를 보면, 명확히 2.0 버전의 9번째 릴리즈와 같은 느낌을 준다. <br>
따라서, v2.0 이 말이 된다.<br>
그러나, 그 옆의 SDK 버전을 보면 버전명이 2.1.202 이다. <br>
갑자기 버전명이 2.1 이기 때문에 v2.1 로 오해하기 쉽다. <br>
이 버전명의 명명규칙은 이해할 수 없고, 이해하고 싶지도 않다. <br>

어쨌든, 명확히 2.1.302 버전을 사용하도록 한다.<br>
참고로, 2.1.202 SDK 를 설치하면 빌드가 되지 않는다. <br>
(현 프로젝트의 target 이 2.1 인데, SDK 는 2.0 이기 때문)

### msbuild 가 아닌 dotent build 사용
 C# 을 빌드하기 위해서는 아래와 같은 커맨드 라인을 사용한다: <br>
$ dotnet build your_cs_proj.csproj <br>
https://github.com/fsprojects/Paket/issues/2697

아래와 같은 커맨드는 동작하지 않는다. <br>
$ msbuild *.csproj <br>
or <br>
$ dotnet msbuild *.csproj <br>


### Visual Studio Express 제약사항
Visual Studio Express 는 첨부된 solution 을 제대로 열지 못한다. <br>
상업용으로 빌드하여 사용한다면 Visual Studio Express 을 설치하고 <br>
커맨드라인툴을 사용해야 한다. <br>

## Ubuntu 18.04
마지막 검증일자 : 2018년 7월 21일 <br>
18.04 Desktop 버전의 Minimal 로 설치 후, 아래의 dependency 를 설치하고 빌드.

### Dependencies 
- .NET Core SDK <br>
( see also : https://www.microsoft.com/net/download/linux-package-manager/ubuntu18-04/sdk-current, last accessed July 16, 2018) <br>
아래 커맨드를 차례대로 사용하여 설치. <br> 
$ wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb <br>
$ sudo dpkg -i packages-microsoft-prod.deb <br>
$ sudo apt-get install apt-transport-https <br>
$ sudo apt-get update <br>
$ sudo apt-get install dotnet-sdk-2.1 <br>
- graphviz <br>
  $sudo apt-get install graphviz
- doxygen <br>
  $sudo apt-get install doxygen
- jdk
  $sudo apt-get install default-jdk

이하는 향 후, C/C++ 테스트 시 필요한 dependencies
- gcc <br>
  $ sudo apt-get install gcc
- g++ <br>
  $ sudo apt-get install g++
- cmake <br>
  $ sudo apt-get install cmake
