param
(
  $token
)

$ver = (gci "$env:userprofile\.nuget\packages\codecov")[0].Name
$cmd = "$env:userprofile\.nuget\packages\codecov\$ver\tools\codecov.exe";
$fName = ".\test\BugJumperCore.Tests\coverage.opencover.xml";
$arg1 = "-f ""$fName""";
$arg2 = "-t $token";
$arg3 = "--flag";
$flag = "production";
& $cmd $arg1 $arg2 $arg3 $flag
