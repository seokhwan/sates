#SET(GCC "yes")
SET(VC "yes")

SET(LIB_BUILD "yes")
add_definitions(-DSATES_FRAMEWORK_INCLUDED)

set(outdir ${CMAKE_SOURCE_DIR}/../../build/${CMAKE_BUILD_TYPE})

set(EXECUTABLE_OUTPUT_PATH ${outdir} CACHE PATH "Build directory" FORCE)
set(LIBRARY_OUTPUT_PATH ${outdir} CACHE PATH "Build directory" FORCE)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${outdir})
set(CMAKE_BUILD_FILES_DIRECTORY ${outdir})
set(CMAKE_BUILD_DIRECTORY ${outdir})
set(CMAKE_BINARY_DIR  ${outdir})

cmake_minimum_required(VERSION 3.8.0)
project(sates_test_cpp CXX)

file(GLOB sates_file ${CMAKE_SOURCE_DIR}/sates/*)
source_group(sates FILES ${sates_file})

file(GLOB internal_use_file ${CMAKE_SOURCE_DIR}/sates/internal_use/*)
source_group(sates\\internal_use FILES ${internal_use_file})

file(GLOB os_file ${CMAKE_SOURCE_DIR}/sates/os/*)
source_group(sates\\os FILES ${os_file})

file(GLOB util_file ${CMAKE_SOURCE_DIR}/sates/util/*)
source_group(sates\\util FILES ${util_file})

file(GLOB report_file ${CMAKE_SOURCE_DIR}/sates/report/*)
source_group(sates\\report FILES ${report_file})

if (GCC)
	file(GLOB os_dept_file ${CMAKE_SOURCE_DIR}/sates/os/linux/*)
	source_group(sates\\os\\linux FILES ${os_dept_file})
endif()

if (VC)
	file(GLOB os_dept_file ${CMAKE_SOURCE_DIR}/sates/os/win/*)
	source_group(sates\\os\\win FILES ${os_dept_file})
endif()

include_directories(${CMAKE_SOURCE_DIR})

if(LIB_BUILD)
	add_library(sates_test_cpp ${sates_file} ${internal_use_file} ${os_file} ${os_dept_file} ${util_file} ${report_file})
else()
	add_executable(sates_test_cpp ${sates_file} ${internal_use_file} ${os_file} ${os_dept_file} ${util_file} ${report_file} main.cpp)
endif()


if (GCC)
	target_link_libraries(sates_test_cpp pthread)
endif()