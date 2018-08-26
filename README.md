# 개정이력

|  날짜  | 내용  | 담당자   | 검수자  | 
|---|---|---|---|
|  2018년 7월 21일 | 검증된 빌드 환경 내용 추가  | 김석환  |  사용자  |
|  2018년 7월 26일 | SDK 주의 #1 수정  | 김석환  |  사용자  |
|  2018년 7월 27일 | How to customize 추가  | 김석환  |  사용자  |
|  2018년 7월 27일 | SATES 소개 추가  | 김석환  |  사용자  |
|  2018년 8월 1일 | SATES 로 가능한 일 추가  | 김석환  |  사용자  |
|  2018년 8월 1일 | SATES 결과물 섹션을 가장 앞에 추가 | 김석환  |  사용자  |
|  2018년 8월 11일 | SPEC 및 테스트에 대한 설명 추가 | 김석환  |  사용자  |
|  2018년 8월 13일 | Visual Studio 관련 개발환경 내용 추가 | 김석환  |  사용자  |
|  2018년 8월 14일 | SATES 시스템 flow 및 예제 추가 | 김석환  |  사용자  |
|  2018년 8월 26일 | Java 튜토리얼 추가 | 김석환  |  사용자  |
 

# SATES 결과물
SATES 를 이용하면 사용자는 아래와 같은 문서를 작성할 수 있다.
- [HTML 및 CHM 압축파일 다운로드](https://github.com/seokhwan/sates/blob/master/build/sates_doc.zip)

# SATES 소개
## SATES (Spec And Test Engineering System) 란?
SATES 는 제목 그대로 Spec And Test Engineering System 의 약자이다. 사양서 및 테스트 케이스를 문서화하고, 테스트코드를 실행하며 이 결과를 다시 문서에 반영하는 등의 과정을 자동화하는 시스템이다. 

SATES 는 아래 보이는 V-Model 의 문서화 지원을 목적으로 한다.

![Alt text](resource/img/readme_img/vmodel_img.png "V Model 개념도, 출처 : https://en.wikipedia.org/wiki/V-Model_(software_development)")


구체적으로 

- SPEC, 테스트 케이스, 테스트 코드, Source 코드 문서 작성
- 작성 문서간의 맵핑 생성 

을 목표로 한다.

## SATES 로 가능한 일
- Doxygen 형식의 SPEC, 테스트 케이스 등 문서 작성 후 생성
- CSharp, C/C++(개발 필요) 유닛 테스트
- SPEC, 테스트 케이스, 테스트 코드, Source 코드 간의 맵핑 문서 생성

## SATES 시스템 flow 및 예제
![Alt text](resource/img/readme_img/sates_big_picture.png "SATES 시스템 개념도")

SATES 시스템은 위의 그림 (a) 박스에 표기된 것과 같이 doxygen 스타일의 텍스트 문서 혹은 json 형식의 커맨드를 입력받는다. Doxygen 스타일의 문서란 아래의 예와 같다.
~~~
@revision
|  날짜  | 내용  | 담당자   | 검수자  | 
|------------|------------|------------|------------|
|  2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |


@title
SPEC (Specification) 관리

@author
Seokhwan Kim

@date

@desc
SPEC이란, Business Requirement, Use Case, SRS (Software Requirement Specification) 등
Software 를 정의 (define, specify) 하는 모든 문서를 의미한다.

Software 를 정의 (define) 한다는 것은 software 가 어떤 기능을 어떻게
수행한다는 것을 명세하는 것이다. SPEC 이런 모든 정보를 포함해야 한다. 

SPEC 의 관리란, 이러한 SPEC 간의 관계의 맵핑을 제공하는 것이다.
위에 열거한 SPEC 들 (Business Requirement, Use Case, SRS 등) 은
서로 밀접한 관계를 맺는다. 


@child_spec
- DOC.SPEC.S01_BIZ_REQ.BR_0002_TEST_MGMT


~~~

위와 같은 형식의 doxygen 스타일 텍스트 문서를 (b) 의 sates 에 입력하면, sates 는 이를 내부적으로 저장한다. (b) 의 sates 는 프로젝트의 sates_core 에 해당하며, 서버 데몬, 서비스 등과 같은 시스템이라고 간주할 수 있다. 참고로, C# 으로 작성되었다. 

sates 는 (c) 에 보이는 것처럼 doxygen 스타일로 꾸며진 소스파일을 생성할 수 있다. 생성된 파일의 예는 아래와 같다.

~~~
namespace DOC.SPEC.S01_BIZ_REQ
{
    /** \addtogroup DOC
    *  @{
    */
    /** \addtogroup SPEC
    *  @{
    */
    /** \addtogroup S01_BIZ_REQ
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  |
    |------------|------------|------------|------------|
    |  2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
    
    

    @title
    SPEC (Specification) 관리

    @author
    Seokhwan Kim

    @date
    

    @desc

    SPEC이란, Business Requirement, Use Case, SRS (Software Requirement Specification) 등\n
    Software 를 정의 (define, specify) 하는 모든 문서를 의미한다.\n
    

    Software 를 정의 (define) 한다는 것은 software 가 어떤 기능을 어떻게\n
    수행한다는 것을 명세하는 것이다. SPEC 이런 모든 정보를 포함해야 한다.\n
    

    SPEC 의 관리란, 이러한 SPEC 간의 관계의 맵핑을 제공하는 것이다.\n
    위에 열거한 SPEC 들 (Business Requirement, Use Case, SRS 등) 은\n
    서로 밀접한 관계를 맺는다.\n
    

    


    @child_spec
    - DOC.SPEC.S01_BIZ_REQ.BR_0002_TEST_MGMT

    */
    class BR_0001_SPEC_MGMT{}
    /** @} */
    /** @} */
    /** @} */

}

~~~

보이는 것과 같이, BR_0001_SPEC_MGMT 라는 이름의 클래스가 위의 텍스트 파일의 내용을 반영하여 생성되었다. 디렉토리 구조에 따라, namespace 및 addtogroup 태그의 내용도 생성되었다.

이와 같은 문서를 다시 (d) 의 doxygen 시스템 (http://www.stack.nl/~dimitri/doxygen/) 에 입력하면, 우리는 다양한 형태의 문서를 생성할 수 있다. 

궁극적으로 (e) 에 표기된대로 문서를 생성할 수 있으며, 위의 예제를 통해 생성한 문서는 아래 그림과 같다.

![Alt text](resource/img/readme_img/example_output.png "출력예제")

## 테스트 툴킷과의 통합
위에 명기하였듯이, sates 는 SPEC 과 TEST 문서간의 통합을한다. TEST 문서는 필연적으로 TEST 결과를 포함해야 하며, 소프트웨어 테스트는 일반적으로 전용 툴을 사용한다. 여기서 전용 툴이란, 어떤 구문이 TRUE 혹은 FALSE 인지, 어떤 값이 동일한지 혹은 동일하지 않은지를 테스하는 기능과 또 구문이 false 로 판명될 경우, 이를 로깅하는 기능, 실행 중 segmentation fault 등이 발생하더라도 해당 케이스를 실패로 판명하고, 다음 케이스를 실행하는 기능 등을 포함한다. (Google Test 의 기능을 상상해보라.) 

이러한 툴킷과의 통합을 위해 개발된 것이 json 형식의 command 이다. 위에 서술한 것과 같이 sates 시스템은 C# 으로 작성되었다. 따라서, C# 의 테스트 코드와는 통합이 바로 가능하다. 하지만, Java, C++ 과 같은 다른 언어와의 통합을 위해서는 이들 언어와의 바인딩 (예: C# 의 interoperability 혹은 Java 의 Jini) 을 활용해야 한다. 이런 바인딩의 경우, 성능은 더 좋을수 있으나, 시스템의 전체적인 복잡도 및 해당 기술과의 커플링이 높아져 결과적으로 재사용성 및 유지보수성에 악영향을 미치게 된다.

이에 대한 대안으로 사용한 것이 바로 json 형식을 사용한 command 방식이다. 참고로 json 은 human readable / editable 한 것이 참 멋진 특성으로 보인다. 아래 그림은 json 커맨드의 예제이다. 

~~~
[
    {
        "api":"test_result_set",
        "args":
        [
            "TU_00001_STRING_TRANSFER",
            "FAILURE",
            "FAIL, filename : D:\\bsd\\sates\\codes\\test_sates_core\\T01_UNIT\\TU_00001_STRING_TRANSFER.cs, method name : TESTCODE.T01_UNIT.TU_00001_STRING_TRANSFER.run(), line : 61"
        ],
        "reserved1":null,
        "reserved2":null,
        "reserved3":null
    },
    {
        "api":"test_result_set",
        "args":
        [
            "TU_00002_FILE_TRANSFER",
            "OK"
        ],
        "reserved1":null,
        "reserved2":null,
        "reserved3":null
    },
    {
        "api":"test_result_set",
        "args":
        [
            "TU_00003_API_CMD_JSON_PARSER",
            "OK"
        ],
        "reserved1":null,
        "reserved2":null,
        "reserved3":null
    },
    {
        "api":"test_result_set",
        "args":
        [
            "TU_00004_TEST_RESULT_REPORTER_JSON",
            "OK"
        ],
    "reserved1":null,
    "reserved2":null,
    "reserved3":null
    }
]
~~~ 

보이는 것과 같이 api 는 함수의 이름이며, 뒤에 바로 args 가 array 형태로 뒤따라 온다. 첫번째 파라메터는 테스트 케이스의 이름, 두번째 파라메터는 성공 / 실패 여부, 그리고, optional parameter 로 실패의 경우, 로그가 따라온다. reserved1, 2, 3 이 뒤따라 온다.

~~~
@revision
|  날짜  | 내용  | 담당자   | 검수자  | 
|------------|------------|------------|------------|
|  2018년 7월 31일 | 문서작성  | 김석환  |  사용자  |

@title
TCP/IP 소켓 활용 스트링 전송

@author
Seokhwan Kim

@date

@desc
Local port 를 오픈 후, 샘플 스트링을 전송하여
해당 스트링이 올바르게 전송되었는지 검사한다.


@ret_code
- sates.util.string_transfer

@ret_spec


~~~

본래의 테스트케이스 문서인 위의 파일과 그 위의 json 메시지를 반영하면, 아래와 같은 테스트케이스 문서가 생성이된다. 
~~~
namespace DOC.TESTCASE.T03_UNIT
{
    /** \addtogroup DOC
    *  @{
    */
    /** \addtogroup TESTCASE
    *  @{
    */
    /** \addtogroup T03_UNIT
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  |
    |------------|------------|------------|------------|
    |  2018년 7월 31일 | 문서작성  | 김석환  |  사용자  |
    

    @title
    TCP/IP 소켓 활용 스트링 전송

    @author
    Seokhwan Kim

    @date
    

    @desc

    Local port 를 오픈 후, 샘플 스트링을 전송하여\n
    해당 스트링이 올바르게 전송되었는지 검사한다.\n
    

    


    @test_result
    FAILURE

    @test_fail_log

    FAIL, filename : D:\bsd\sates\codes\test_sates_core\T01_UNIT\TU_00001_STRING_TRANSFER.cs, method name : TESTCODE.T01_UNIT.TU_00001_STRING_TRANSFER.run(), line : 61\n

    @ret_spec
    

    @ret_code
    - sates.util.string_transfer

    */
    class TU_00001_STRING_TRANSFER{}
    /** @} */
    /** @} */
    /** @} */

}
~~~

보이는 것과 같이 test의 결과 및 fail 의 경우, 이의 로그가 삽입되었다.

그리고, 이를 다시 doxygen 으로 생성하면 아래와 같은 문서가 생성이된다.

![Alt text](resource/img/readme_img/test_output_example.png "테스트 결과 포함 문서 예제")



# How to build & run (Java)
## Windows
### Build
- ./sates/scripts/win 으로 이동하여 100_build.bat 을 실행한다. <br>
$ 100_build.bat

- 기본 build 디렉토리로 이동 <br>
$ cd ..\..\build\Debug\netcoreapp2.1\

- sates_core.dll 실행 <br>
$ dotnet sates_core.dll

- 다시 ./sates/scripts/win 으로 이동하여 또다른 command prompt 열고 아래라인을 순서대로 실행 <br>
$ 300_sates_java_build.bat <br>
$ 301_java_code_build.bat <br>
$ 302_java_test_build.bat <br>

- java 프로그램 실행 <br>
$ 303_java_test_run.bat

## Ubuntu
- ./sates/scripts/ubuntu 으로 이동하여 100_build.sh 을 실행한다. <br>
$ ./100_build.sh

- 기본 build 디렉토리로 이동 <br>
$ cd ../../build/Debug/netcoreapp2.1

- sates_core.dll 실행 <br>
$ dotnet sates_core.dll

- 다시 ./sates/scripts/ubuntu 으로 이동하여 또다른 command prompt 열고 아래라인을 순서대로 실행 <br>
$ ./300_sates_java_build.sh <br>
$ ./301_java_code_build.sh <br>
$ ./302_java_test_build.sh <br>

- java 프로그램 실행 <br>
$ ./303_java_test_run.sh

## Java 결과확인
Windows 와 Ubuntu 모두, <br>
./sates/example/javaout/ 이하의 디렉토리에 DOC 및 파일들이 생성된 것을 확인할 수 있다. 특히, /sates/example/javaout/DOC/TESTCASE/T03_UNIT$/TU_00003_MULTIPLICATION.cs 파일을 보면 아래와 같이 test 가 실패한 경우, 이에 대한 로그가 남는 것을 확인할 수 있다. (@test_result, @test_fail_log 부분).
~~~
namespace DOC.TESTCASE.T03_UNIT
{
    /** \addtogroup DOC
    *  @{
    */
    /** \addtogroup TESTCASE
    *  @{
    */
    /** \addtogroup T03_UNIT
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  |
    |------------|------------|------------|------------|
    |  2018년 8월 15일 | 최초작성  | 김석환  |  사용자  |


    @title
    덧셈기능 검증

    @author
    Seokhwan Kim

    @date


    @desc


    @test_result
    FAILURE

    @test_fail_log

    FAIL, filename : TU_00003_MULTIPLICATION.java, method name : run, line : 29\n

    @ret_spec


    @ret_code


    */
    class TU_00003_MULTIPLICATION{}
    /** @} */
    /** @} */
    /** @} */

}
~~~
## svn / github checkout

## 코드 편집
./code/test_sates_core/Program.cs 파일의 const string DEFAULT_PATH 스트링 편집

# How to customize
## Doxygen 태그 추가
./resource/doxy/sates_doxy 파일의 55번째 줄에서 시작하는 ALIASES 을 편집한다.



# 빌드환경
## Microsoft Windows

마지막 검증 일자 :  2018 년 8월 13일

| 항목 | 버전 |
|------|-----|
| 버전 |  Windows 10  [Version 10.0.17134.167] |
| C/C++ Compiler | Microsoft (R) C/C++ Optimizing Compiler Version 19.14.26433 for x86 |
| C# Compiler | Microsoft (R) Visual C# Compiler version 2.8.3.63029 (e9a3a6c0) |


### Dependencies 
- doxygen 1.8.14 * <br>
https://sourceforge.net/projects/doxygen/
- graphviz 2.38 * <br>
https://graphviz.gitlab.io/download/
- Plantuml v1.2018.8 * <br>
http://plantuml.com/
- Java SE Development Kit 8u181 <br>
http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html
- .NET Core SDK x64 (v2.1.302) <br>
https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.302-windows-x64-installer


\* 가 표기된 doxygen, graphviz, plantuml 은 dependency 디렉토리에 포함되어 있음.

## 주의
### .NET Core SDK 버전 (2018년 8월 13일)
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

### Visual Studio 설치권장
현재 C#, C++ 을 빌드하기 위해서는 사실은 C#과 C++ 의 컴파일러, 그리고 관련된 library 가 필요하다.
C#의 경우에는 .NET Core SDK 에, C++ 의 경우에는 Windows SDK 에 컴파일러와 헤더 등이 포함되어 있을 것을 <strong> 예상된다. </strong>

이러한 부분을 모두 하나 하나 정확히 파악하는 것은 사실 개발환경 설정 측면에서 무척 중요하다.

하지만, 나는 위의 부분에 대해 현시점에 명확히 파악하고 싶은 의사가 없다. 따라서, 가단히 사용 가능한 Visual Studio 2017 버전의 설치를 강력히 권장한다. 이하는 각 버전 별 참고사항이다.

#### Visual Studio Professional 2017 이상 설치 권장
codes/sates.sln 파일은 Visual Studio 2017 Professional 이상의 버전에서 사용이 가능하다.

#### Visual Studio Express 2017 (상용 개발자 with no 라이센스)
상용 개발의 경우에는 Visual Studio Community Edition 도 사용이 불가하다. 마지막 남은 옵션은 Visual Studio 2017 Express 버전을 설치하는 것이다. 다행시 express 버전도 SATES 에서 사용하는 헤더 및 라이브러리는 모두 설치되기 때문에 빌드에 문제가 없다. 

참고로, deploy 용 바이너리 역시 express 버전을 설치한 가상머신에서 빌드하고 있다.

참고로, Visual Studio Express 에서는 codes/sates.sln 파일의 오픈은 불가하다.

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

# C#
## Coverage 데이터 추출
### 설치 필요 파일
- coverlet (C# Code Coverage) <br>
https://github.com/tonerdo/coverlet <br>
Developer Command Prompot for VS 2017 실행 <br>
아래 행 입력하여 설치
$ dotnet tool install --global coverlet.console 
- ReportGenerator <br>
https://github.com/danielpalme/ReportGenerator

### Coverage 데이터 추출 커맨드라인
#### coverlet
예를 들어, C:\sates 에 설치된 경우 : <br>
coverlet C:\sates\build\Debug\netcoreapp2.1\test_sates_core.dll --target "dotnet" --targetargs "test C:\sates\codes\test_sates_core\test_sates_core.csproj --no-build"  --format cobertura

#### Report Generator
reportgenerator -reports:coverage.cobertura.xml -targetdir:report



## SATES 개발 배경 
### 가벼운 문서 맵핑 툴
SATES 를 개발하게된 첫번재 동기는 가벼우면서 또한 문서간의 맵핑이 생성되는 툴킷을 내가 사용하고 싶었기 때문이다. 입사 후, 회사에서 본격적으로 소프트웨어 개발을 시작하게 되었다. 학창시절부터 프로그래밍을 좋아하였고, 또, 신뢰성있는 소스코드를 작성하는 것에 흥미를 느꼈기 때문에 수많은 문서화에 대해 거부감은 없었다. 다만, 내게 맞는 문서화 툴이 없음을 느끼게 되었다.

사실 부족하다기 보다는 너무나 무겁거나 비싸기 때문에 내가 접근할 수 없는 경우가 많았다. 세상에는 수많은 (아주 전문적인) 문서화 도구가 있다. 하지만, 개인적으로 개발자는 문서작성과 소스코드 작성 및 디버깅을  하나의 에디터에서 할 수 있어야 한다고 생각한다. 나 역시 개발자 이지만, 개발자란 무척이나 게으르며 또한 개발관련 이외의 배움에 있어 은근히 배타적이다. (그렇지 않은 개발자들에게는 미안하다.) 예를 들어, 회사에 아무리 좋은 IBM Doors 와 같은 요구사항관리 시스템이 있어도, 개발자들에게 이를 사용하기 위해 무거운 SW 를 실행해야 한다거나 혹은 어떤 웹에 접속하여 로그인을 해야한다면 개발자들은 그 툴에서 점점 멀어진다. 그리고, 코딩과 문서화는 별개의 작업이되며, 절대 동시에 실행하지 않는다. (명심하자. SW 문서화는 코딩과 동시에 진행하지 않으면 안된다.)

그래서 SATES 를 개발하게 되었다. 모든 문서는 doxygen 과 같은 형식의 텍스트 파일로 작성하고 소스코드 내부에 문서와 소스코드 파일명 등의 링크를 편집해주면 이를 모두 통합하여 하나의 문서로 만들어주는 시스템 (즉, SATES) 을 생각하게 되었다. 하지만, 그런 툴이 존재하지 않아, 직접 개발하게 되었다.

이 툴을 활용하여 나는 복잡한 전문도구를 활용하지 않더라도, 

- <strong>소스코드, 사양서, 테스트케이스, 테스트 코드 를 모두 맵핑한 문서</strong>
 
을 가질 수 있기를 기대한다.

### 공유를 위한 목적
나는 이 프로젝트를 공유하고자 한다. 나는 우리나라의 개발자들이 문서화를 좀 더 잘했으면 한다. 문서화가 잘되면 SW 산업이 전체적으로 조금 더 발전할 것이라고 믿는다. 그리고, 이는 궁극적으로 개발자인 내게도 분명 유익한 일이 될 것이다.

회사에 근무하면서 많은 개발자들이 문서화를 싫어하고, 결과적으로 문서작성 능력이 낮은 것을 알 수 있었다. 나이의 많고 적음 그리고 직급의 높고 낮음에 관계없이 많은 개발자들에게 이러한 면을 볼 수 있었다. 소프트웨어 관련 전공을 하는 경우, 학부 1학년 때부터 SW 의 문서화는 무척 중요하다는 말을 많이 듣는다. 그럼에도 SW 문서화를 싫어하고, 문서화를 하지 않다보니 문서작성 능력이 없는 개발자들이 많은 것이 현재의 현실이다. 

왜 그러할까? 에 대해 개인적으로 찾은 이유는 다음과 같다. 

첫째, 경험의 부족이다. 문서화에 대해 거부감을 가지고 있는 개발자들을 보면 대부분 개발의 경험이 그렇게 풍부하지 않은 것을 볼 수 있다. 여기서 말하는 개발 경험의 풍부함이란 어떤 소프트웨어를 처음부터 작성하여 수 년간 유지보수를 하는 경험을 의미한다. 아무리 머리가 좋은 천재 개발자라고 하더라도 본인이 3년전에 작성한 코드를 정확히 기억할 수는 없다. 3년전에 작성한 코드에 문제가 발생하여 갑자기 수정이 필요할 때, 개발자에게 절대적으로 필요한 것은 그 당시에 작성한 문서이다. 그 문서는 당신의 시간을 절약해 줄것이다.  그러한 경험이 없는 개발자는 문서화의 유용함을 경험하지 못했기 때문에 문서화를 거부할 수 밖에 없다.

둘째, 역시 경험의 부족이다. "개발자는 코드로 이야기한다" 라는 아름다운 말을 마치 "개발자는 코딩만 잘하면 그만이다." 라는 말로 곡해하는 개발자들이 있다. "개발자는 코드로 이야기한다." 라고 말을하며, 어떤 문서화도 하지 않는 것이 정당화 되려면 당신이 작성한 코드는 완벽해야 한다. 여기서 완벽이란, 이해관계자 중 그 누구도 당신의 코드에 대해서 영원히 불만을 표출하지 않는 것을 의미한다. 현실적으로 불가능하다. 실제 실무에서는 품질담당자, 상품기획담당자 등 많은 부서의 사람들과 대화하고, 그들에게 왜 그렇게 코드를 작성하였는지 설명을 해야하는 일이 많다. 그리고 대부분의 경우, 이들은 전혀 코드를 이해하지 못한다. 이들은 오로지 자연어로 작성된 문서만을 이해한다. 품질 문제를 이야기하는 품질담당자에게 개발자는 잘 정리된 사양서, 테스트케이스, 테스트결과서를 보여주며 협의해야 한다. 사양적 측면에 대한 문제를 이야기하는 기획담당자와는 사양서를 보여주며 협의해야 한다. 당신은 코드로 이야기하고 싶을지 모르겠으나, 실제로는 코드로 대화하는 것이 아니라, 문서로 대화하는 것이다. 당신은 코드를 작성하겠지만, 대화는 문서를 통해 이루어진다. 그리고 대부분 회사에서 코딩보다는 대화가 분명히 더 중요한 일이다.

셋째, 좋은 예제를 본적이 없다. 개인적으로 볼 때, 이것이 가장 큰 이유이다. "SW 의 문서화는 무척중요하다." 라는 말을 무척 많이 하지만, 실제 학생 시절에 제대로 문서화가된 소스코드 및 문서를 보기가 어렵다. 제대로 문서화를 한다는 것은 장기간 동안 요구사항서 등의 문서와 소프트웨어 소스코드가 관리될 때 가능하다. 이러한 관리는 사실 회사에서 어느 정도 프로세스를 통해 시스템적으로 강제하지 않으면 잘 되지 않는다. 그리고, 물론 이러한 문서와 소스코드는 외부에 공개하지 않는다. 따라서, 학생이 회사에 입사하기 전에 이러한 문서화 및 소스코드를 체험하기는 현실적으로 어렵다. 아이러니하다. 우리는 SW의 문서화를 강조하고 있지만, 이의 좋은 예에는 접근하기 무척 어려운 환경에 놓여져 있는 것이다. 

나는 이 프로젝트가 하나의 참고할만한 좋은 예가 되었으면 한다.

## SATES 문서의 기본 디렉토리 구조 설명
### 도입
SW 문서를 읽는 것을 마치 교과서처럼 읽으면서 무엇인가 쉽게 배울 수 있을 것이라고 기대하는 사람들이 있다. SW 문서가 그렇게 작성된다면 더할 나위가 없을 것이다. 그렇게 문서를 작성하면 좋겠지만, 나는 그러한 능력은 없는 것 같다. 따라서, SATES 의 문서는 무척 딱딱하다. 여러분의 양해를 바란다. 

SW 문서화에서 문서가 읽기 쉬운 것보다 더욱 중요한 것은 문서의 내용이 오해가 없도록 작성되는 것이다. SW 문서는 프로그래밍 언어와 같아야 한다 (Context Free Grammar). 즉, 누가 읽어도 오해가 없도록 중의적 표현이 없어야 하며 또한 모든 내용은 검증가능한 (Testable) 한 표현을 사용하여 해당 내용의 합불판정이 명쾌할수 있도록 작성되어야 한다. 

그렇다고 이 글이 모두 그렇게 작성되었다는 것은 아니다. 그렇게 작성하려고 노력을 했다. 여러분께서 글을 읽다가 중의적 혹은 testable 하지 않은 표현이 있다면 가감없는 연락을 부탁드린다. 코드가 개발 후 수많은 디버깅의 시간을 요구하듯, 문서 역시 수많은 검증의 시간을 요구한다.

### V-Model 의 흐름
앞서, SATES 는 V-Model 의 문서화 지원을 목표로 한다고 명기하였다. SATES 의 docs 의 directory 구조는 아래 그림과 같다. Directory Tree 구조는 항상 아름답다.

```
├── FMEA
├── SPEC
│   ├── S01_BIZ_REQ
│   ├── S02_SRS
│   │   ├── R01_USECASE
│   │   ├── R02_FUNCTIONAL
│   │   └── R03_NON_FUNCTIONAL
│   └── S03_SW_DESIGN
│       ├── D01_STATIC_VIEW
│       └── D02_DYNAMIC_VIEW
├── TESTCASE
│   ├── T01_ACCEPTANCE
│   ├── T02_INTEGRATION
│   └── T03_UNIT
```

크게 FMEA, SPEC, TESTCASE 디렉토리가 가장 상위에 위치하고 있다. 현재 FMEA 는 지원하지 않는다. (2018년 7월 27일) SPEC 은 내부적으로 S01_BIZ_REQ, SRS (Software Requirements Specification), SW (Software) Design 디렉토리가 있다. 다음 절부터 각 디렉토리에 해당하는 문서가 무엇인지, 그리고 그 문서에 대한 나의 짧은 생각을 적도록 한다.

#### S01_BIZ_REQ (Business Requirements)
비즈니스 요구사항은 사실 일반적으로 개발자들에게 쉽게 다가서지 않는 개념이다. 그리고, 사실 실무 개발자가 실제 작성할 일은 극히 드물다고 할 수 있다. 하지만, 이는 실제 개발업무에 있어서는 생각보다 매우 중요하다. 일단, 왜 중요한지에 대해 명확히 하고자 한다. 그렇지 않으면, 이 항목의 존재의 이유가 없다. 당위성이 없는 항목은 작성할 필요가 없는 항목이다. (코드도 필요없는 코드는 삭제가 원칙이다.)

일반적으로 회사에서 비즈니스 애널리스트 (BA: Business Analyst) 들이 바로 비즈니스 요구사항을 도출하는데, 이 비즈니스 요구사항이란 해당 소프트웨어 프로젝트를 통해 이루고자 하는 비즈니스 관점의 최상위 관심사항 (concern) 이라고 할 수 있다. 가령, 은행시스템의 프로젝트인 경우, "창구의 혼잡도를 30% 감소시켜 고객만족도를 50% 향상시킨다." 가 비즈니스적 요구사항일 수 있다. 아주 솔직하고 정확히 이야기해보자. 우리에게 프로젝트 개발을 발주한 고객사는 우리가 그렇게 소중하게 생각하는 소스코드에 관심은 전혀없다 (소프트웨어 개발 자체가 목적인 프로젝트는 제외) 고객은 철저히 비즈니스 요구사항에 관심이 있다. 

개발자들이 간과하는 것 중 하나가 소프트웨어 개발은 SRS 를 만족시키는 것이라고 오해하는 것이다. 물론 최말단의 실무개발자에게는 일반적으로 그 이상을 요구하지 않기 때문에 그럴수 있다. 하지만, 깨달아야 한다. 우리의 목표는 SRS가 아닌 비즈니스 요구사항의 만족이다. 아무리 SRS 를 100% 만족시키는 소스코드를 개발한다 할지라도 고객의 비즈니스적 요구를 충족시키지 못한다면, 그 프로젝트는 실패한 프로젝트로 판명될 것이다. 안타까운 일이다.

그렇다면, 도대체 소스코드는 비즈니스 요구사항과 어떤 관계를 갖는 것일까? 예를 들어보자. 은행시스템에서 고객만족도 향상 이라는 비즈니스 요구와 또 다른 비용절감 이라는 비즈니스 요구가 있다고 하자. 당신이 어떤 부분의 소스코드를 작성하는데, 두 가지의 선택이 있다. 하나는 비효율적으로 메모리를 매우 많이 사용하지만 속도가 무척 빠른 라이브러리 A 가 있고, 또다른 메모리는 매우 적게 효율적으로 사용하지만 속도가 꽤 느린 라이브러리 B 가 있다고 가정하자. 비즈니스 요구사항이 "고객만족도 향상" 이라면, 당신은 A 를 선택해야한다. 만약 "비용절감" 이 비즈니스 요구사항이라면 B를 선택해야한다 (HW 비용이 줄어들 확률이 높다) SRS, 설계에서 이런 부분까지 모두 상세하게 정의하기는 어렵다. 하지만, 우리가 비즈니스 요구사항을 명확히 인지하고 있다면, 이와 같이 상세하게 정의되지 않았지만 어떤 결정이 필요할 때, 이를 참고할 수 있고, 결과적으로 이러한 노력들은 프로젝트가 비즈니스 요구사항을 만족시킬 확률을 높혀줄 것이다. 

이러한 원칙은 사실 SRS, 소프트웨어 설계에도 모두 적용이 된다. 예를 들어, 비용절감이 우선인 프로젝트의 경우 가용한 HW 의 가격에 맞추어 가용한 CPU 및 메모리 자원의 한계가 SRS에 명기될 것이고, 시스템은 그 자원내에서 동작하게끔 설계되어야 할 것이다. 예를 들어, 모든 통신을 텍스트 기반의 메시지형태로 주고 받는 아주 커플링이 낮은 시스템 설계 보다는 유지보수성은 좋지 않지만 성능에 유리한 운영체제의 바이너리 인터페이스 (즉, dll 혹은 so 파일) 를 활용하는 상세설계가 주어질 것이다. 

비즈니스 요구사항은 프로젝트의 헌법과 같은 역할을 한다.

#### S02_SRS (Software Requirements Specification)
대학학부의 많은 수업에서도 요구사항 작성의 연습을 하고, 서점에는 요구사항 작성법, 요구공학과 같은 서적들이 많이 있다. 그만큼 소프트웨어 요구사항의 작성이 어렵다는 것을 반증하는 것이 아닐까 싶다. 생각해보라. "두발로 걷는법"과 같은 수업이나 책은 없다. 누구나 쉽게 할 수 있기 때문이다.

필자는 요구사항 전문가가 아니다. 단, 스스로 요구사항을 작성하고, 이를 바탕으로 소스코드를 작성하고, 자주테스트를 진행하며 이를 몇년간 유지보수한 경험이 있다. 이 경험을 바탕으로 요구사항에 대한 내용을 작성하고자 한다.

요구공학의 내용들을 보면, risk, penalty, 필요공수 등 많은 내용을 포함하게 되어있다. (http://processimpact.com/pubs.html 참조) 해당 내용들을 모두 작성할 수 있다면 좋겠지만, 사실 요구사항을 추출하는 시점 (일반적으로 프로젝트의 착수단계) 에 이러한 내용들을 모두 정확하게 추출하기는 어렵다. 이제 시작하는 프로젝트에서 risk 가 어느정도 인지 어떻게 정확하게 예측할 수 있는가? 아직 작성해 보지도 않은 코드가 얼만큼의 공수가 필요한지 어떻게 알 수 있는가? 따라서, 처음부터 이러한 내용을 모두 작성하는 것은 현실적으로 어렵고 추천하고 싶지 않다.

다만, 일단 아래의 항목만을 포함하여 작성하는 것을 권장하고 싶다. 

- 우선순위 
- 검증방법

사실 위의 두 항목은 필자가 만났던 수많은 컨설턴트 및 요구공학 전문가들이 다른 것은 몰라도 꼭 필수로 포함할 것을 권장하는 단 두가지 항목이다. 

우선순위의 중요성은 언급할 필요가 굳이 없을 것 같다. 대입시험을 준비한다면, 가장 배점이 높은 국영수를 먼저 공부하듯이 우리는 가장 중요한 일부터 먼저해야 한다. 우선순위가 높은 일을 먼저하자는 것에 이의를 제기하는 사람은 많이 없을 것이다.

검증방법은 요구사항 만족의 여부를 판단하기 위한 정보를 제공한다. 소스코드는 요구사항 만족을 위해 작성되어지는데, 이 코드가 요구사항을 만족하는지 여부에 대한 판단 방법은 개발자 혹은 품질담당자의 합의를 통해 해당 방법의 명문화가 필요하고, 요구사항 문서는 이를 포함해야한다. 

Iterative & Incremental

Divide and Conquer 와 함께 내가 무척 좋아하는 문구이다. 요구사항은 한번에 완성될 수 없다. 요구사항은 프로젝트의 시작과 지원종료의 시점까지 함께하는 문서이다. 프로젝트 초기에 알 수 없다고 했던 내용들 (필요 공수, risk 등) 은 프로젝트가 진행되면서 조금 더 구체적으로 파악이 될 것이다. 그런 내용들을 끊임 없이 추가해야 한다. 

이와 함께, 요구사항은 고객과 호흡하며 현장에서 발생되는 추가 요구 및 결함을 지속적으로 반영해야 한다. 예를 들어, 어떤 결함이 발생한다면 개발자가 먼저 해야할 일은 해당 결함이 요구사항을 만족시키지 못하여 발생한 것인지, 요구사항 자체가 해당 결함의 내용을 포함하고 있지 않은지를 확인해야 한다.

예를 들어, 
- 어떤 센서값이 0 에서 1로 변경되면, 시스템은 정지한다.

라는 요구사항이 있는데, 고객사에서 센서값이 0 으로 유지됨에도 시스템이 정지한다는 결함이 보고되었다고 가정하자. 알고보니, 센서는 약 1시간 1번 정도 0.01 초 정도 값이 1로 변경되는 현상이 있다고 한다. 센서는 정상이지만, 외부 환경의 요인으로 그런 일이 발생가능하다는 것을 센서 제조업체로 부터 확인 받았다. 그렇다면, 요구사항은 아래와 같이 수정되어야 한다.
- 어떤 센서값이 0에서 1로 1초 이상 변경되면, 시스템은 정지한다.

조금 더 명확해졌다.

얼마 후, 시스템이 또 갑작스럽게 정지하는 현상이 있다는 고객사의 리포트가 도착했다. 확인해 보니, 센서의 고장으로 인해 30분마다 한번씩, 센서값이 변경되는 경우가 발생하고 있었다. 센서 제조업체에 문의 결과, 센서의 값이 1시간이 2회 이상 변경되는 것은 센서의 고장확률이 높다는 회신을 받았다. 이런 경우, 아래와 같은 요구사항이 추가되어야할 것이다.
- 센서 값이 0에서 1로 변경되는 현상이 1시간 이내에 2회 이상 발생하면, 센서의 고장으로 간주하고 센서점검 안내 메시지를 표시한다. 시스템은 정지한다.

위와 같은 요구사항의 수정 및 추가는 시스템의 지원이 종료되는 시점까지 반복된다. 점진적 반복적으로 요구사항은 발전하고, 시스템은 이에 맞게 수정이된다. 이 과정은 참 아름답다. 시간이 변해감에 따라 요구사항을 수정하고, 시스템은 이에 맞게 발전되어 가며 신뢰성이 높아지는 과정은 진정 아름답다.
  
#### S03_SW_DESIGN (Software Design)
요구사항은 시스템이 수행해야할 기능을 명세한다. 이제 이 기능을 어떻게 구현할 것인가에 대해서 고민해야 한다. 소프트웨어 디자인이란 바로 이 "어떻게" 를 표현한다. 소프트웨어 설계 문서는 각 설계는 어떤 요구사항과 연결이 되며 또한 어떤 소스코드와 연결이 되는지 명확히 문서화가 되어야 한다. 

소프트웨어 설계 문서는 일반적으로 (필수적으로) 아래의 두 항목을 포함해야 한다.
- Static View
- Dynamic (Runtime) View

Static View 는 클래스 다이어그램, 패키지 다이어그램 등 일반적으로 SW 콤포넌트들이 소스코드상에서 어떻게 관계를 이루고 있는지를 보여준다.

Dynamic View 는 시퀀스 다이어그램이 좋은예로 Static View 에 표현된 콤포넌트들이 실제로 런타임에 어떻게 동작하는지를 보여준다.

Len Bass 의 Software Architecture in Practice 는 꼭 한 번 읽어볼 것을 권장한다.

### TESTCASE
Business Requirements, SRS, SW Design 은 공통적으로 소프트웨어가 어떻게 동작해야 하며, 어떻게 구현되었는지 그 사양을 설명한다. 이러한 문서에 작성된 사양 (SPEC) 은 검증이 되어야 하며, 테스트는 이 검증을 실행하는 것을 의미한다. 나는 소프트웨어 테스트 전문가가 아니다. 하지만, 감히 말하건데 모든 소프트웨어 개발자는 테스트에 대해서 어느정도 전문가가 되어야 한다고 생각한다. 본인이 수행한 일에 대해서 최소한의 범위에서라도 검증을 하여 본인의 일이 완수되었음을 스스로 증명하는 것은 엔지니어라는 직함을 가지고 있다면, 너무나 당연히 수행해야할 일이다.

초등학교 수학시간에 우리는 "검산" 이라는 개념을 배운다. 우리는 수학을 이용해 문제를 푸는 것을 배우면서 동시에 내가 푼 답이 맞는지 검증하는 "검산" 을 배운다. 문제를 푸는 것 만큼이나 해답이 올바른지 검증하는 것은 무척 중요한 것이다. 초등학교에서 배우는 것은 일반적으로 "진리" 이다. 

소프트웨어 테스트에 대해서 꼭 한 가지 여러분과 공유하고 싶은 생각이 있다. 바로 테스트의 "자동화" 이다. 소프트웨어의 아름다운 점 한가지는 모든 테스트가 거의 "자동화"가 가능하다는 것이다. 실물에서 동작하는 로봇, 자동차 등에 탑재되는 소프트웨어도 사실 실물의 데이터만 캡쳐해 놓은 것을 마련하면 테스트는 자동화가 가능하다. 소프트웨어 세상에서 모든 테스트는 자동화가 가능하다. 의지만 있다면.

어떤 조직이 어떤 소프트웨어를 작성하든 출시 이후, 회사에는 수많은 고객의 불편사항, 개선점이 리포트된다. 그리고, 이러한 개선점 / 오류사항 중 해결의 필요가 있는 것은 모두 요구사항에 새롭게 반영되며 점점 소프트웨어는 발전해 나간다. 오랜 기간 동안 사업을 하며 얻은 이러한 경험적 지식은 회사의 사실상 가장 중요한 자산 (Asset) 이다. 10년 만에 한 번 경험하는 오류. 전혀 예상하지 못했던 고객의 사용 시나리오. 전혀 예상하지 못한 외부 환경 변수. 에 대해서 우리는 모두 상응하는 테스트 케이스를 작성해야 하고, 이를 검증하는 코드를 작성해야 한다. 그리고, 이 테스트를 자동화 해야한다.

자동화된 테스트의 실질적인 이익은 이를 활용할 때 발생한다. 예를 들어, 어떤 새로운 제품을 개발했을 때 테스트가 자동화 되어 있다면 우리는 그 제품에 지난 수십년의 경험이 쌓인 테스트를 바로 적용해볼 수 있고, 그 때 비용은 거의 ZERO 에 가깝다. 이것이 바로 SW 의 힘이며 테스트 자동화의 힘이다. 바로 그토록 경영진이 항상 이야기하는 비용절감의 기술적 솔루션이다. 아름다운 일이다. 

아직도 소프트웨어를 손으로 직접 테스트를 하고 있는 회사가 있다면, 진정 말씀드리고 싶다. "자동화 하라"

#### T03_UNIT
테스트는 역순으로 가장 작은 단위인 단위테스트 부터 인수테스트의 순서로 설명한다. 

단위테스트는 가장 많이 들어본 테스트일 것이다. 단위테스트의 방법은 간단히 테스트 대상이 되는 클래스 혹은 함수에 예상되는 입력을 넣어 예상되는 출력이 발생하는지 확인하는 것이다. 그리고, 가능하면 각 테스트는 코드의 전체를 cover 하게끔 작성한다. 현존하는 대부분의 언어는 단위테스트를 지원하는 툴킷이 존재한다. SATES 도 기본적인 단위테스트 함수를 제공한다. 

단위테스트 실행 시, coverage 툴을 활용하여 가능한한 100%의 coverage 를 달성하면 무척 유익하다. 

#### T02_INTEGRATION
통합테스트는 단위테스트 보다 조금 더 큰 단위의 테스트이다. 일반적으로 하나 이상의 콤포넌트를 테스트하고, 하나의 use case scenario 를 테스트하기에 적합하다. 

소프트웨어가 어느 정도 완성된 후, 고객사 혹은 유관부서의 피드백 등은 대부분 하나의 use case scenario 로 정리가 가능하고, 대부분의 use case scenario 는 여러 개의 콤포넌트가 통합되어 실현된다. 이러한 하나 하나의 시나리오를 검증하는 코드가 통합테스트의 한 예이다.

소프트웨어가 향 후 라이브러리 형태로 제공될 계획이 있다면, 통합테스트는 예제코드로서 역할도 가능하다. 이 점을 염두에 두고 통합테스트를 작성한다면, 향 후 라이브러리로 출시할 때, 예제코드 작성의 수고를 덜어낼 수 있다. 


#### T01_ACCEPTANCE
일반적으로 인수테스트 라고 이야기 한다. 인수테스트의 범위를 설정하는 것은 굉장히 모호하다. 이상적인 인수테스트는 고객이 사용하는 실환경에서 모든 시나리오에 대한 테스트를 실행하는 것이다. 하지만, 현실적으로 불가능하다. 

따라서, 기본적으로 개발환경에서 통합테스트를 최대한 성실히 수행하여 개발 수준에서의 검증을 완료하고, 인수테스트는 이를 실환경에 적용하여 대표적인 테스트 케이스를 진행하는 것으로 실행 가능하다.

예를 들어, 실물과 함께 동작하는 소프트웨어라면 (자동차, 로봇 등) 실물과 함께 테스트하는 것이 가능할 것이고, 통합테스트를 순차적으로 수백 - 수천번 반복하여 문제가 없는지 테스트를 해보거나 혹은 웹서버의 경우라면 과거의 사용패턴을 그대로 답습하여 그대로 동작을 시켜보는 것. 즉 실제 운용환경과 가장 비슷한 환경에서 실제 서비스에 준하는 테스트가 가능할 것이다. 이는 각 회사 및 조직에서 적절히 선정해야할 것이다.

