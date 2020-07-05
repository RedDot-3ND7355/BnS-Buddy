▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▀▄▀▄                                             Endless                                              ▄▀▄▀
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓


Disclaimer: 
+If game is rendered unstartable, you are the only one responsible. Therefore using this tool, you agree to the "risks".

> You can always use the Original NCSoft Launcher to restore files to Original and start the game


Credits:
+ Miyako - Inspired by his/her BnS-Ark Tool!
+ Endless aka Kogaru - Recoded from scratch and improved!
+ ronny1982 - For bnsdat tool 
+ LokiReborn - For porting bnsdat to C# and adding AuthToken
+ Yevvie - For Icons, Splash art and BnS Buddy Forum images
+ Airix - For providing a battleground fix
+ GunerX - For providing upk numbers for animation toggles
+ Yeti - For finding AMD ULPS interfering with bns performance
+ Megai2 - For his dx12 proxy mod for better bns performance


Requirements:
+ .Net Framework 4.5 (not client profile)
+ MetroFramework.dll (included in download)

> A brain.


Change Log:

Update 5.9.5.0
+ Added: General lang for error prompts
+ Added: Online grab of current key sets for each regions
+ Updated: Extracting of Dat files for regions that has the updated check
+ Updated: Added new method to check for Garena region paths via MUI cache
+ Fixed Bug: Emails ending with more than 3 characters after last dot would not be accepted
+ Fixed Bug: Color of prompts would not be applied before certain events

Update 5.9.4.8
+ Updated: RU region key has been updated 
+ Fixed Bug: Unhandled exception when users patches game files with already running game

Update 5.9.4.7
+ Added: Chinese region support
+ Added: Toggle to check for D912PXY updates
+ Updated: Chinese region key has been updated
+ Updated: NA and EU region key has been updated
+ Fixed Bug: Version check for frontier was broken
+ Fixed Bug: Korean paths were not switched properly when going live/test/frontier
+ Fixed Bug: Frontier paths were not fully supported
+ Fixed Bug: Censored text for error or crash logs was not censoring the proper information
+ Fixed Bug: Increased timer to detect processes to avoid hangs due to slow I/O on systems

Update 5.9.4.6
+ Added: Toggle to keep cache or not at users risk
+ Updated: D912PXY now has an external management window
+ Updated: Libs now has updated DotNetZip
- Removed: Deprecated libs
+ Fixed Bug: Installing D912PXY would only work once until next startup
+ Fixed Bug: Using D912PXY overall would hang the app for no reason
+ Fixed Bug: Getting the country code from certain countries would result a 404 on geolocation plugin for code generator
+ Fixed Bug: Popup would not appear above buddy under certain conditions

Update 5.9.4.5
+ Added: Support for 3rd spec sin animation in animation toggles
+ Fixed Bug: Multiple installations was not updated for the latest regions added

Update 5.9.4.4
+ Fixed Bug: Some files were not supposed to be touched anymore on certain toggles oopsie 

Update 5.9.4.3
+ Fixed Bug: Path remembered was not used on certain conditions and caused the remembered path to not load before registry check

Update 5.9.4.2
+ Updated: Internal updater has been updated
+ Updated: Garena(VN/TH) Key has been updated
+ Added: Support for Frontier server has been added in korean

Updater 2.5.4.3
+ Fixed Bug: Internal library did not match updated and would cause crash on start
+ Fixed Bug: Even if no update was available, auto update routine would run

Updater 2.5.4.2
+ Fixed Bug: Internal libraries were outdated and prevented users from auto extracting update on certain languages of the os

Version 5.9.4.1
+ Updated: JP Key has been updated
+ Fixed Bug: Auto update would do absolutely nothing

Updater 2.5.4.1
+ Fixed Bug: Auto update would do absolutely nothing

Version 5.9.4.0
+ Updated: TW Key has been updated
+ Added: Remember the last path browsed to for the garena region client files
+ Fixed Bug: The warning icon at the top bar would float in the middle of nowhere when buddy is maximized for dat editing

Version 5.9.3.9
+ Fixed Bug: Even if garena was uninstalled from the system, garena registry would stay in regedit and trigger a browse to folder

Version 5.9.3.8
+ Added: Garena region support with manual path selection
+ Oups: Removed some annoying popups i forgot to remove while testing

Version 5.9.3.7
+ Fixed Bug: Key for KR/RU Region was improperly encoded
+ Fixed Bug: Cancelling a region swap browse to folder will crash buddy and/or cause many error popups
+ Fixed Bug: MultiClient window would not appear certain times 

Version 5.9.3.6
+ Added: Russian region support
+ Added: By region AES key for xml files
+ Fixed Bug: A measure I have implemented was not compatible with every system language
+ Fixed Bug: D912PXY Update Check would do a seperate thread and users would still be able to modify the toggle and break the ui and crash

Version 5.9.3.5
+ Fixed Bug: Startup routine and play routine is broken due to last update

Version 5.9.3.4
+ Updated: The encryption/decryption key for xml files has been updated to new one
+ Added: Proper handler for empty replace lines on addons
+ Removed: Archer Effects and KFM 3rd Spec Effects from toggles for compatibility with another tool
+ Fixed Bug: When starting game the interval cleaner would do a traditional clean of itself and not the game
+ Fixed Bug: Restoring addons with empty replace line threw an error

Version 5.9.3.3
+ Oups: Forgot to remove certain popups that was used in testing from previous release

Version 5.9.3.2
+ Added: Line breaks has been added to patches for addons

Version 5.9.3.1
+ Updated: Save as for dat editor now supports x16 and text file types
+ Fixed Bug: Dat Editor save as would ignore the file extension and save as xml anyway
+ Fixed Bug: TimeStamp would have an extra space
+ Fixed Bug: Selecting all addons would show the description of the last one selected by it
+ Fixed Bug: When changing tab to mod manager, new lines would appear with no log and only timestamps
+ Fixed Bug: When loading or reloading files on dat editor, the old status would still show

Version 5.9.3.0
+ Added: Proxy honoring for advanced users
+ Added: Toggle for Maintenance Check
+ Added: Toggle for timestamp in logs
+ Added: Extra check for Certificate
+ Updated: server for update fetching has been updated
+ Optimized: Startup process of buddy is now REALLY faster
+ Fixed Bug: Toggles for BnS Version Check and Maintenance Check in settings page 4 were ignored

Updater 2.5.4.0
+ Added: Extra check for Certificate
+ Updated: server for update fetching has been updated

Updater 2.5.3.5
+ Added: Loading form for users to know if the updater is loading or not
+ Fixed Bug: Unhandled error while fetching the bns buddy server status

Version 5.9.2.9
+ Added: Toggle for BnS Version Check for faster BnS Buddy Startup
+ Updated: Some Nu-Get Packages were outdated

Updater 2.5.3.1
+ Added: Updater build on gui
+ Added: Build comparer for users to know if their updater is the latest

Version 5.9.2.8
+ Fixed Bug: Users being able to resize and break the gui on start
+ Fixed Bug: Users after they switch tab to launcher would see more and more empty lines on logs

Version 5.9.2.7
+ Reworked: Entire Signature validation has been improved and overhauled for maximum effeciency
+ Added: Support for lower res images for mod preview
+ Fixed Bug: Refresh would not delete all unexisting mods
+ Fixed Bug: Textboxes on launcher would not be at the bottom on start

Updater 2.5.3.0
+ Reworked: Entire Signature validation has been improved and overhauled for maximum effeciency

Version 5.9.2.6
+ Removed: Scrolling behaviour on dropdown for server selection and all to prevent hang
+ Updated: Changed how the compat flags is handled and added for more accuracy
+ Updated: The message for the warning of compat entries has been modified, popup added for easier understanding and what are your options
+ Updated: The list of supported image type for mod preview under the help button
+ Fixed Bug: GETULPS Would have null references and crash on start because errors are not handled
+ Fixed Bug: Mod Manager would color non installed mods with installed mods even if they are not conflicting
+ Fixed Bug: After applying addons, logs would not stay in the box
+ Fixed Bug: Invalid images would throw an error in mod preview
+ Fixed Bug: Clear Compat button would not clear the entries

Version 5.9.2.5
+ Renamed: AMD ULPS for easier understanding
+ Enabled: Ingame memory cleaner is back and improved
+ Updated: IDs for korean login/maintenance/version were changed
+ Updated: NCLauncher.ini has been changed and detection system has been updated
+ Added: A Seperate patch button in addons so users would not require to start game to patch games files if wanted
+ Added: Enhanced innerexception and stacktrace for error reports
+ Fixed Bug: Handling of corrupted file on startup of checking backup configs
+ Fixed Bug: Bool was not properly used to check if region was selected or not
+ Fixed Bug: Mail check on login input is broken
+ Fixed Bug: Parent node having sub folders would skip sub node if parent contained mods
+ Fixed Bug: Parent node not unticking after installing/uninstalling
+ Fixed Bug: Handler for unexisting folder mods would not remove invalid child and parent treenode
+ Fixed Bug: Mod Manager would not clear the entire parent if it had childrens and all does not exist
+ Fixed Bug: Mod Manager would not color both child and parent if both were conflicting and would throw error

Version 5.9.2.4
+ Added: Handler for patch files with no replace value
+ Added: Archer animation toggle
+ Added: 3rd spec animation toggle to KFM toggle
+ Added: D912PXY mod for win10 and win7 users only
+ Added: ULPS Toggle for AMD GPUs in extras to maximize performance
+ Added: Prompt warning when fth entries exists
+ Added: Manual selection of cores to run the game on
+ Added: Toggle for affinity manager
+ Added: Support for lower cased N in BNS for version file check
+ Added: Startup entry for BnS Buddy toggle in settings
+ Added: Handling of whitespace in email during login
+ Reworked: Detection of installed mods when installed with files
+ Reworked: Handling of Compat flags and fth are now seperate
+ Reworked: Handling of same folder name in modmanager but different mod files
+ Reworked: Partially reworked the settings handling for easier management
+ Fixed Bug: Launcher logs wouldn't be scrolled down auto for certain users
+ Fixed Bug: Mod Manager logs wouldn't be scrolled down at all without it being shown first
+ Fixed Bug: Keep-in-tray toggle would not dispose bns buddy logo in tray when closed
+ Fixed Bug: Typo for assassin in extras
+ Fixed Bug: Double clicking the mod manager list would trigger triple state
+ Fixed Bug: Startup spinner would not follow the settings color
+ Fixed Bug: Buddy would not close if icon or BW was already disposed
+ Fixed Bug: Typing invalid characters into text field would crash or cause an error
+ Fixed Bug: The theme code validation would not be the theme color selected
+ Fixed Bug: Receiving broken code validation emails when some info could not get grabbed by ncsoft
+ Fixed Bug: Overlapping box in extras
+ Fixed Bug: Unhandled errors when using unstable connection and could not connect to bns buddy domain
+ Fixed Bug: A rare dns bug would occur on ncsoft dns records and could not login anymore
+ Fixed Bug: Remote ip grab would hang and crash the login process
+ Fixed Bug: Adding/Modifying/Removing a folder in mod manager would create a duplicate of the entire tree
+ Fixed Bug: Uninstalling 2 mods or more of the same name would create an index error
+ Fixed Bug: Two mod folder of same name would both be green if only one of them is installed

Updater 2.5.2.0
+ Added: Server status so users will know why the download button is grayed out
+ Added: Admin permission required from start
+ Fixed Bug: Unhandled errors when using unstable connection and could not connect to bns buddy domain

Version 5.9.2.3
+ Optimisation: Buddy startup is faster
+ Optimisation: Loading affinity window now loads faster without hang
+ Fixed Bug: Starting buddy while server timeout occured hangs buddy
+ Fixed Bug: Wanting to update within buddy would freeze the app when server timeout occured
+ Fixed Bug: Some extras features were overlapping others
+ Fixed Bug: Loading bar now displayed properly on affinity window

Version 5.9.2.2
+ Added: Scrollbars for Launcher text log and mod log
+ Added: Keep in tray toggle added to settings
+ Fixed Bug: Applying addons with a damaged dat file would result in an error
+ Fixed Bug: Picturebox for splash changer was out of bounds
+ Fixed Bug: When selecting a xml file to edit in dat editor, it would be loaded twice since v5.9.1.7

Version 5.9.2.1
+ Fixed Bug: Wrong strings were used for login to ncsoft servers
+ Fixed Bug: Wrong local version string was used

Version 5.9.2.0
+ Fixed Bug: Version check was checking the wrong strings
+ Fixed Bug: Version check was missing a backslash when on different windows version

Version 5.9.1.9
+ Added: Reload button in dat editor
+ Added: Custom affinity
+ Added: Custom path support for nclauncher 2
+ Added: Version check for supported regions
+ Updated: Ip for na server
+ Reworked: Changed how the settings are handled when changed
+ Fixed Bug: Installing/Uninstalling parent folder of sub mod would cause an error/crash
+ Fixed Bug: Added a null check for bit selection
+ Fixed Bug: Leaving enter code empty and submitting would crash buddy
+ Fixed Bug: Changing some settings and having the settings file missing would cause an error

Version 5.9.1.8
+ Added: Restoring already running buddy if new instance exists
+ Fixed Bug: Not being able to move mod folders for new mod manager would cause an io exception
+ Fixed Bug: Installing/Uninstalling a mod which the folder does no longer exist would trigger an error

Updater 2.5.1.9
+ Fixed Bug: Popups styling from buddy would be broken and button would overlap
+ Fixed Bug: Not being able to move new update would cause an io exception

Version 5.9.1.7
+ Added: A plus button for a full description for the mod
+ Added: Preview button in mod manager
+ Added: Help button for mod manager
+ Added: Beautify button to dat editor for xml cleanup
+ Added: Syntax check for dat editor to prevent corrupted files
+ Added: Disabling menu options when game is already running
+ Added: Save as xml button for dat editor
+ Added: Colors to installed mods
+ Added: Installed mods conflict check
+ Added: Sub mods to mod manager
+ Modified: Mod Manager to install mods with symlinks for faster operations & save space
+ Modified: Applying/removing mod buttons renamed
+ Reworked: Detection of installed mods
+ Reworked: Mod manager does it's job with threads instead of background worker
+ Fixed Bug: Duplicate process check within tick would cause error if overlapped
+ Fixed Bug: Grabbing color on other forms even if settings.ini didn't exist crashed buddy
+ Fixed Bug: BackColor for treeview for xmls in dat editor goes black randomnly and not readable
+ Fixed Bug: Popups styling from buddy would be broken and button would overlap

Version 5.9.1.6
+ Added: Detection if game is already running
+ Added: Killing the already running game if Auto game killer is OFF
+ Added: Comment support for dat editor
+ Added: Autofix syntax color for comments in Dat
+ Removed: Popups when clearing count in extras
+ Updated: Detection for NCLauncher 2 settings
+ Updated: Credits has been modified
+ Fixed Bug: Allowing the user to start the game without having a region selected first

Version 5.9.1.5
+ Added: Support for NCLauncher 2
+ Added: Numpad support for Code Entry
+ Removed: an Ad from ads
+ Updated: Upk numbers for new skills
+ Updated: Regex for ping check
+ Fixed Bug: last used server was not remembered
+ Fixed Bug: Context for restoring via dat editor was wrong
+ Fixed Bug: Panel for multiclient would stay even if no game session was on

Version 5.9.1.0
+ Fixed Bug: Clicking on a folder in dat editor would lock file list
+ Fixed Bug: Previously used data in code verification wouldn't be discarded

Version 5.9.0.9
+ Fixed Bug: Changelog was not appearing when updating via BnS Buddy

Version 5.9.0.8
+ Reworked: Autofix for Settings.ini
+ Fixed Bug: The trigger for the autofix was incomplete

Version 5.9.0.7
+ Updated: Credits in about
+ Updated: A proper check for Settings.ini autofix
+ Fixed Bug: A check for the local files if directory does not exist
+ Fixed Bug: A check for existing dat files in the dictionary
+ Fixed Bug: Ping check for Korean server
+ Fixed Bug: Update Button wasn't available when an update was
+ Fixed Bug: Closing the verification form locks the play button

Updater 2.5.1.8
+ Fixed Bug: Overwriting an existing BnS Buddy when updating would crash the updater

Version 5.9.0.6
+ Added: Auto fix for Settings.ini
+ Added: Corruption detection of dat files in dat editor
+ Added: local dat files were added to dat editor
+ Updated: Internal updater
+ Updated: KR Arguments for client
+ Reworked: Routine to check if game is patched or clean
+ Fixed Bug: Progress tracker for Mod Manager
+ Fixed Bug: Dependecy fix for some pc
+ Fixed Bug: Dependecy collision check
+ Fixed Bug: Bad Coloring on Update Transition Form
+ Fixed Bug: Auto-extracting of BnS Buddy Updater

Updater 2.5.1.7
+ Fixed Bug: Dependecy fix for some pc
+ Fixed Bug: Dependecy collision check

Version 5.9.0.5
+ Added: New ad in Ads page (rotated)
+ Added: Toggle for Battleground crash fix
+ Updated: Ping refresh is now 5s by default
+ Updated: Added a warning when switching animations toggle when game is running
+ Reworked: Dat Editor entirely reworked
+ Fixed Bug: Visual glitch of arrow in Dat Editor
+ Fixed Bug: MultipleInstallations would throw null on some systems
+ Fixed Bug: When addons did not contain [bit] log would throw wrong message
+ Fixed Bug: Could not paste in Verification Code box
+ Fixed Bug: When Password is wrong on login, play button would be locked
+ Fixed Bug: Missing Icon for Login Form
+ Fixed Bug: FileCheck Form would cause a crash
+ Fixed Bug: Wasn't able to submit login when pressing enter
+ Fixed Bug: Changed the ip for kr server ping (might not work for every countries)
+ Disabled: Memory cleaner while game is active until we find the cause of the memory leak

Version 5.9.0.4
+ Added: Warden to Animation toggles
+ Added: Notifications for FTH
+ Added: Validations for xml search / replacement in addons (ex. If you forget a > it will reject the change so it doesn’t break the game)
+ Updated: NCoin logo to the NCoin symbol for Buy NCoin
+ Updated: Minimum ping interval to 1s and max to 5s
+ Reworked: Functionality of .dat (de)compressing to support extraction/insertion of specific file(s) without the need to open the entire archive
+ Reworked: Server communication for login as well as support for IP Verification
+ Removed: Annoying popups when Clearing FTH Entries
+ Fixed Bug: Login issue for NA/EU (supports both known values incase NcSoft reverts the change)
+ Fixed Bug: Few elements to show proper color on color change in Extras
+ Fixed Bug: Auto-scrolling for text log on the Launcher Page

Version 5.9.0.3
+ Fixed Bug: FTH Get count would cause a crash

Updater 2.5.1.6
+ Fixed Bug: A bad color check in settings.ini would prevent updater from starting/loading.

Version 5.9.0.2
+ Fixed Bug: BnS Buddy is prevented from starting

Version 5.9.0.1
+ Added: FTH Toggle with clear entries button
+ Added: Select all addons buttons
+ Added: Prevention of going to 64bit client if the system is 32bit archetype
+ Updated: Donor list
+ Removed: Black Color Style to the theme
+ Fixed Bug: TabStop for login
+ Fixed Bug: Changing Theme color would not change tile colors for menu
+ Fixed Bug: White Style has broken Menu color
+ Fixed Bug: When changing style the Merch button wouldn't change style until tab changed
+ Fixed Bug: Mod Manager buttons not available cancelling a game start attempt or sign in
+ Fixed Bug: When class animations are toggle on and off, buttons weren't available

Updater 2.5.1.5
+ Added: Run as admin by default
+ Fixed Bug: Could not run without admin rights

Version 5.9.0.0
+ Added: Buy Ncoin Merch link
+ Added: Sliding Menu & Slider Effect Toggle(settings page 2)
+ Added: Run as admin by default
+ Removed: Tabs
+ Fixed Bug: Flickering issue when loading buddy
+ Fixed Bug: Bad tooltip shown for "kill game"

Version 5.8.9.9
+ Added: Toggles for class animations in extra tab
+ Added: Update Dialog for manual updates with changelog
+ Fixed Bug: Prevent preview(button) if splash is invalid

Version 5.8.9.8
+ Added: Skip/Remove ads with your secret key that you have found
+ Added: Custom splashes now included in BnS Buddy (Artwork by Yevvie)
+ Added: Image dimensions now shown on splash changer after selection
+ Added: A Small check for TLS 1.2 while fetching version
+ Reworked: The icons
+ Reworked: Reposition of the admin check
+ Reworked: Moved splashes to local like addons
+ Reworked: Changed TW's ip for an 100% accurate ping
+ Fixed Bug: Added an additionnal null check for previous sessions
+ Fixed Bug: Opening an invalid bmp file would error out Splash Editor with out of memory error
+ Fixed Bug: Kill Game button would start new session if cancelled multiclient login popup
+ Fixed Bug: The infinite-click decompile/compile/... is now properly fixed
+ Fixed Bug: Subfolders in addons path would cause a file not found error
+ Fixed Bug: BnS Budy would kill all Clients if failed to login(timeout)
+ Fixed Bug: MXM Conflict check wouldn't discard after appearing once
+ Fixed Bug: Using DAT Editor functions with some KR users would spit errors of path not being good

Version 5.8.9.7
+ Added: New Icons (Artwork by Yevvie)
+ Reworked: Rewritten a few things related to color
+ Fixed Bug: Error trying to delete a folder non-recursively
+ Fixed Bug: Pressing X on login form to forget user no longer worked
+ Fixed Bug: Time out response from login
+ Fixed Bug: Quickly double clicking the decompile on dat editor tab would freeze Buddy

Version 5.8.9.6
+ Added: Ads *Jumps into the world of sponsoring*
+ Added: Automatically extract MetroFramework.dll when missing
+ Removed: Popup for missing MetroFramework.dll file
+ Reworked: Splash changer now properly checking if splash is modded or not AND changed to where BnS Buddy is located
+ Fixed Bug: Pressing Refreh in splash changer and switch tab back and forth will error out the viewer

Version 5.8.9.5
+ Added: Popup for missing MetroFramework.dll file
+ Added: Auto-resize for email in login form
+ Added: Single-Instance only check
+ Added: Disabled auto-login by default if MultiClient is turned on
+ Added: 5 Seconds delay between clicks for refresh of user count to prevent spam and hang
+ Reworked: Changed the forget button to an X
+ Reworked: Fetching on AppStart would hang form for a couple of seconds
+ Fixed Bug: Changing remember me on login form would not sync with settings tab
+ Fixed Bug: Changed ip for TW server due to inaccurate ping
+ Fixed Bug: Fetching while having a slow connection to end-point for user online count would freeze the form
+ Fixed Bug: Unsecurely Fetched the user online count
+ Fixed Bug: Having Selected Japanese server would switch back to NA/EU if it was installed
+ Fixed Bug: Tooltip for Custom Client Name would be wrong
+ Fixed Bug: When BnS Buddy would be offline, it would try to fetch the count and have an overlapping html code
+ Fixed Bug: Wanting to login would wipe constantly the registry of the credentials
+ Fixed Bug: After wiping credential would cause crash

Version 5.8.9.4
+ Added: Timer to say if connection is being slow during login
+ Added: Custom exe name for Client
+ Added: User count online
+ Added: Color dropdown for BnS Buddy's design
+ Added: Portuguese support
+ Added: Sorting to Addons
+ Added: Sorting to Splashes
+ Added: Remember last used server
+ Added: Preview Button in Splash Changer
+ Added: Context Menu to BnS Buddy Notification Icon When Minimized
+ Reworked: Ping method for na/eu
+ Reworked: Mod manager now moves mods to subfolders for better organisation
+ Reworked: Multiple Game Installation Resetting
+ Reworked: Changing Server would load different installed paths
+ Reworked: Changed addons location
+ Reworked: Repositioned the Bitness selection for the game Client & Changed the Default Path configuration
+ Reworked: Bitness selection for addons is automatically selected along with the bitness selected of the current client
+ Fixed Bug: Matching prefix for emails before @ would create duplicate entries of the same name
+ Fixed Bug: Sometimes pressing tooltip on xml edit tab would not work
+ Fixed Bug: Did not allow login after maintenance is over on same session
+ Fixed Bug: Would not load korean paths
+ Fixed Bug: Custom mod path would not have backup path following
+ Fixed Bug: Creating random /mod folders on root drive
+ Fixed Bug: Restore button in settings didn't do anything
+ Fixed Bug: Maximize/Minimize button went batshit crazy and didn't follow his orders when resizing form
+ Fixed Bug: Remember Me did not toggle unless you signed in on login form
+ Fixed Bug: Emails starting with the same name will be overwritten on registry
+ Fixed Bug: Cleaning Mess when exiting, starting game and opening BnS Buddy would not clean
+ Fixed Bug: Removed the excessive flickering when BnS Buddy Refreshed the Mod Manager list
+ Fixed Bug: Fixed tooltips still appear after pressing compile/decompile
+ Fixed Bug: Disabled the compile/decompile when game is running which resulted in a permanent freeze
+ Fixed Bug: Pressing Compile button on dat editor when not decompiled would crash/freeze BnS Buddy
+ Fixed Bug: Applying a mod in mod manager while folder is empty and none other selected would freeze BnS Buddy
+ Fixed Bug: Splash Preview within BnS Buddy wasn't respecting image ratio
+ Fixed Bug: Buddy would not be killed if closed via taskbar
+ Fixed Bug: Status for clean or patched files would always stay patched if was previous true

Version 5.8.9.3
+ Reworked: Mod manager handling
+ Fixed Bug: Auto-login wouldn't let you connect to second account
+ Fixed Bug: Would not load korean paths (workaround)
+ Fixed Bug: Unknown error caused by unique fingerprint
+ Fixed Bug: Killing an unexisting process
+ Fixed Bug: Mod Manager renaming mod folders when not finished transferring
+ Fixed Bug: Keeping old updater not allowing to update
+ Fixed Bug: Loop of applying fix loading screen when files already pre-existed
+ Fixed Bug: Icmp servers from ncsoft would be unpingable, now pinging servers directly
+ Fixed Bug: Modifying cleanint and prtime if previously matching would modify both at the same time
 
Version 5.8.9.2
+ Added: Auto-login
+ Added: Logs during login process to make the login more understandable
+ Reworked: Client killer saves the last used client process id
+ Fixed Bug: Restoring/Reapplying loading screen fix was checked when not and did the opposite
+ Fixed Bug: When no server are available, unhandled exception occurs and crashes
+ Fixed Bug: When one account fails to login all other sessions closes
+ Fixed Bug: When decompiling a multiple folder mod via addon
 
Version 5.8.9.1
+ Reworked: Give access by default to MultiClient on Extra tab 
+ Fixed Bug: Was allowing twice the same acc login at the same time
+ Fixed Bug: Adding non-patch files to the list
+ Fixed Bug: Loading screen bug caused by bns buddy
+ Fixed Bug: Memory cleaner was intrusive to game process in it's cleaning
+ Fixed Bug: Could not show IGP estimation if GCD estimation wasn't on
+ Fixed Bug: When no process are listed as running, tried to set to an unexisting process 

Version 5.8.9.0
+ Added: Start 2nd instance of game Client with multiclient
+ Added: Remember unique key
+ Added: Forget account in Login Form For selected one
+ Added: Support for umap files in Mod Manager
+ Added: Toggles for GCD and INGAME estimations
+ Reworked: Extra tab for 'hidden' features was incomplete
+ Reworked: Relocated Memory cleaner when game starts
+ Fixed Bug: Could not enter custom patch name when creating addon
+ Fixed Bug: The colors for Launcher tab
+ Fixed Bug: Removed "Could not Start Client.exe!" even after it started
+ Fixed Bug: Could not kill Client (Access Denied even with admin rights) globally called Client
+ Fixed Bug: Forgot to add Korean Test Server support Paths
+ Fixed Bug: Error decrypting key via registry for login
+ Fixed Bug: Couldn't properly choose for Live or Test server
+ Fixed Bug: White clickable lines appeared in about tab

Version 5.8.8.6
+ Added: Signature check
+ Added: Server validation to fetch online build number
+ Added: Estimated GCD time response
+ Added: Estimated InGame time response
+ Added: Korean Test Server Registry Path
+ Reworked: Completely reworked Fix Loading Screen & Backup check for it
+ Fixed Bug: Trying to login when maintenance was occuring lead to error
+ Fixed Bug: Korean Test server appid was replaced with proper one
+ Fixed Bug: Login form would error out if Registry could not be read
+ Fixed Bug: Color wether ping was good or not was not changing
+ Fixed Bug: Password would take more than 16 characters wich prevents users to login if password was originally longer than 16 chars
+ Fixed Bug: Tab selector would go out of bounds for too many items
+ Fixed Bug: Pinging wrong adress for na
+ Fixed Bug: Signature of BnS Buddy re-added due to a dependency build issue

Version 5.8.8.5
+ Added: Maintenance Check(handler)
+ Added: Korean Test server option
+ Added: Interval(repeat) for autoclean
+ Rework: Fix Loading Screen now properly removes even if one of them is missing, same for restoring
+ Fixed Bug: Mod Manager tab buttons not working after game killed/closed
+ Fixed Bug: Boost Process would not auto start
+ Fixed Bug: Memory Cleaner would not auto clean

Version 5.8.8.0
+ Removed: Forgot a popup while updating settings.ini
+ Fixed Bug: Setting Custom Mod Folder Would be blank in settings.ini 

Version 5.8.7.9
+ Added: Priority boost when focusing BnS Game Process
+ Removed: Removed the popups after updating Buddy for changes made to settings.ini
+ Fixed Bug: Starting BnS Buddy with game killer check on would prevent it from working

Version 5.8.7.7
+ Fixed Bug: Refreshing addons would only remove 1-2 from the list instead of all modified items

Version 5.8.7.6
+ Reworked: Applying addons now has option for bitness
+ Fixed Bug: Fix Server Selection for NA/EU resulting an unhandled exception

Version 5.8.7.5
+ Fixed Bug: Check settings.ini if updated was broken due to invalid settings name
+ Fixed Bug: Collision with MXM(Add an extra check for mxm registry and in NCLauncher.ini)
+ Fixed Bug: Addons would still compile a multiple pattern patch
+ Fixed Bug: Not being connected to the internet would prevent buddy from attempting to sign in again(play button grayed out)

Version 5.8.7.4
+ Added: Create addon function
+ Added: Login for Taiwan and Korean now supported
+ Added: Warning when restoring files in dat editor
+ Added: Remember me function for language path used if multiple
+ Removed: Backup feature for addons
+ Reworked: Restore button in launcher tab edits and restores the option to default
+ Reworked: Undo Selected Addon instead of restore files
+ Reworked: Recompile addons that mods were applied to (and reverting)
+ Reworked: Cleaning of the editing folder used by buddy replacing new files with old ones
+ Fixed Bug: When not choosing a language would ask for path instead and loop
+ Fixed Bug: Bad path formats would lead to user documents
+ Fixed Bug: Wrong arguments for other clients
+ Fixed Bug: Don't proceed unpacking if file does not exist(if tamepered)
+ Fixed Bug: Don't proceed patching an unexisting file within config files
+ Fixed Bug: Annoying popup that says what language you selected
+ Fixed Bug: French localisation server automatic selecter
+ Fixed Bug: Registry subkey did not exist thus causing errors when memorizing user credentials

Version 5.8.7.3
+ Fixed Bug: Compiling the same xml multiple times
+ Fixed Bug: Remember last signed in user
+ Fixed Bug: Untick addons after done patching/compiling
+ Fixed Bug: Closing Login form returns to Buddy
+ Fixed Bug: Restore in launcher tab not finding path if backup did not exist
+ Fixed Bug: Login Form won't remember previous entered login if a second user was forgotten


Version 5.8.7.2
+ Fixed Bug: Description Text for Addons overflowed out of app.
+ Fixed Bug: Users not remembered caused by old version of buddy
+ Fixed Bug: Files not clearing upon exit in login form
+ Fixed Bug: Addons tab not working(not decompiling or compiling)
+ Fixed Bug: Server setting not recognized when reading nclauncher.ini
+ Fixed Bug: Addons Triggered without wanting it to

Version 5.8.7.1
+ Added: Auto Memory Cleaner at game start and Memory Cleaner Button
+ Added: Multiple Account Remember me
+ Fixed Bug: Packet Buffer empty due to lost connection crashes BnS Buddy
+ Fixed Bug: Restoring addons automatically on startup prevented users to open game
+ Fixed Bug: Backup and restore for addons weren't implemented properly
+ Fixed Bug: Applying any addons would hang app.
+ Fixed Bug: Fixed popup in Login form weren't proper style
+ Fixed Bug: Password encryption weren't enough suffisticated 
+ Fixed Bug: Ok button on help window for login wasn't positioned properly

Version 5.8.7 (TESTING PHASE)
+ Server: Unblocked all countries that could not download BnS Buddy, online version check and updater 
+ Added: Custom paths for mods (General use) 
+ Added: Automatic restore of config/config64 if modded to skip error at client start 
+ Added: Game Process Killer after started 
+ Added: Addons (Patches the mods you want automatically after every launch) 
+ Added: Routines to determine wich Lang path you are actually using if multiple are found 
+ Added: Process Priority dropdown in settings page 3 
+ Added: Japan Support 
+ Added: Korean Support 
+ Fixed Bug: Kept asking wich client version you wanted to run if the paths were found by default at start
+ Fixed Bug: The first ping is now in background worker instead of main thread, preventing freeze at start
+ Fixed Bug: When game won't start and dies. A popup will ask to verify your ip.
+ Fixed Bug: Forms in tabs won't fit and goes out of bounds
+ Fixed Bug: Form won't change when tab is changed
+ Reworked: Changed ip to check your game ping correctly (na & eu)
+ Reworked: Login Form

Version 5.8.5
+ Fixed Bug: Setted Default Client wouldn't switch back to 32bit

Version 5.8
+ Removed: Static paths to Language
+ Removed: Static paths to Client.exe
+ Added: Recursive check for Language
+ Added: Recursive check for Client.exe (32bit & 64Bit)
+ Added: Option to change from 32bit to 64bit in settings
+ Added: Saving of Client choice as default launcher
+ Reworked: Using of path to Client.exe

> You can now change the default client in settings page 2

Version 5.7
+ Removed: Integrated Updater
+ Added: External Updater/Downloader
+ Reworked: Settings.ini handling not overwriting current settings after update
+ Reworked: Change Text in Settings for easier understanding of wich is wich of Client/Game paths

> You can now use the Updater-Downloader to download BnS Buddy

Version 5.6
+ Removed: Static checks for Server/Lang
+ Removed: bnsdat tool (.exe) from project
+ Added: Support for 64bit Client and Config files
+ Added: Recursive checks for Server/Lang
+ Added Selector to choose default installation
+ Added: Default installation path if user has multiple BnS installed
+ Added: integrated functions to extract/compile .dat files
+ Fixed Bug: Wrong window sizes causes items to go out-of-bounds
+ Fixed Bug: Fix crashing of Tool when .dat is already decompiled
+ Fixed Bug: Fix crashing issues at startup due to lack of catches and nulled arguements being called 
+ Fixed bug: Fix button not being able to restore after first patch
+ Reworked: Every Popups to use the theme
+ Reworked: Dat handling to support 64 and 32

Version 5.5
+ Removed: Useless message box when saving xml in dat editor
+ Added: catches for [un/re]packing dat files during startup for debugging
+ Rework: Automatic Updater
+ Rework: Catching the exited popup to avoid crash
+ Fixed Bug: Crash caused by bnsdat at start in CheckConfigBackup
+ Fixed Bug: Saving custom client path would read as gamepath instead
+ Fixed Bug: Tab would start in different location than stated
+ Reworked every closing function for the app

Version 5.4
+ Removed: Custom .dat files from Dat Editor
+ Removed: Presetted .dat files from combobox in Dat Editor
+ Added: Recursive dat files adder and finder in Dat Editor
+ Added: First time use setting
+ Added: Taiwan server support
+ Reworked: Finding game path and setting path values, now recursive
+ Reworked: Dat Editors functions, fully recursive
+ Reworked: Recursive cleanup after restarting tool and after usage
+ Reworked: Restoring modded config files recursively
+ Fixed Bug: Tools boxes goes out of bound when switching tabs
+ Fixed Bug: Saving custom paths in settings adds itself in settings.ini multiple times even if it exists
+ Fixed Bug: Reading custom paths in settings returns the function used instead of actual value
+ Fixed Bug: When Update Check is "off" the status check in launcher tab overlaps the Box on the right
+ Fixed Bug: Admin check function wasnt being called by proper method
+ Fixed Bug: Closing the pop-up for choosing directory of game or launcher would crash the app
+ Fixed Bug: Topmost bug, form stays ontop of everything

> Donation: Added lovely community members

Version 5.3
+ Added: New updater(updates by itself)
+ Added: Option to turn off auto-updater
+ Fixed Bug: minimizing to tray not working
+ Fixed Bug: installing a mod in Mod Manager when the file is unique cant be uninstalled
+ Fixed Bug: when removing loading screen, one upk may remain if another doesnt exist
+ Fixed Bug: restoring files were only moved if its backup existed in mod manager
+ Fixed Bug: restoring settings to default did not remove variables and wasnt set off
+ Fixed Bug: listbox for splash changer errors out when empty
+ Fixed Bug: error handling when splash changes when empty
+ Fixed Bug: installing/uninstalling would be done all at same time and confuses tool

> Unhid the dll for the tool because people could not see it when the tool needed it to run

- Version 5.2.5
+ Fixed Bug: old required files that are no longer required were preventing tool to launch because they werent deleted before removing that folder

- Version 5.2
+ Fixed Bug: bnsdat.exe preventing tool to launch
+ Fixed Bug: update download would give empty file due to no User Agent
+ Fixed Bug: applying patch in dat editor when file does not exist crashes app
+ Fixed Bug: could only mod one at a time and could not restore using Mod Manager
+ Added: Application loading form
+ Added: Custom input file for Dat Editor 
+ Added: Scroll between values for rate of ping(ms)
+ Added: Kill background workers based on settings(off=kill/on=start)
+ Added: Save trackbar(ms) value to settings.ini automatically
+ Modified: Mod Manager 3.0
+ Modified: About Tab

> Known bugs with Dat editor with custom files not unpacking.

Version 5.1
+ Fixed Bug: Dat Editors size would randomly resize itself smaller
+ Fixed Bug: Weird white boxes in settings tab
+ Added: Save custom arguements

Version 5.0
+ Fixed Bug: List box for Splash Changer had the wrong colors on start
- Removed: Use all available cores arguement from the game start
- Removed: Checking backup of config.dat
+ Added: 32-bit compatibility registry values to find Launcher and Game Paths
+ Added: Automatic config.dat patcher
+ Added: Toggle for using Use All Available Cores Arguement
+ Added: Extra Settings (page 2)

> The 32-bit reg check is untested, plz report any errors

Version 4.6
+ Fixed Bug: Wrong startup default tab
+ Fixed Bug: Maximize button shown upon startup (in wrong tab)

Version 4.5
+ Fixed Bug: No use-agent for getting newest version
+ New Mod Manager (2.0)

> Mod Manager 2.0 is in BETA! Report any errors

Version 4.2
+ Completed Dat Editor(BETA)
+ Fixed Bug: Hanged app caused by Ping running as mainworker and not background
+ Fixed Bug: Config.dat Checks were comparing to original(old), now compares to modded instead
+ Fixed Bug: Pings were resulting in errors and crashing app when offline

> Dat Editor is in BETA stage, may result in errors

Version 4.1
+ Partial Touch-up of the .dat editor
+ Fixed Bug: Settings not properly reverting.
+ Fixed Bug: Check config.dat after updates wasnt properly implemented
+ Fixed Bug: Update causing config.dat being invalid for Client.exe
+ Fixed Bug: Check Tab routine not running because form is not initialized
+ Fixed Bug: Login to NCSoft repeating itself after successful login
+ Fixed Bug: Update Check for tool causing unknown errors when not connecting

> NCSoft login travel time reduced
 
Version 4.0
+ Added proper logs to Mod Manager
+ Added settings tabs
+ Started .dat editor (incomplete)

> Relocated the Settings.ini for the app

Version 3.7
+ Changed App Icon to distinguish between game
+ Added new Donators to the donate tab 

> Did some fixes on the Login to NCSoft, wich will not be published as of yet

Version 3.6
+ Fixed Bug: Splash Changer not putting the selected splash
+ Fixed Bug: Values not written when auto-saved functions where set when last run
+ Fixed Bug: Did not compare config.dat after updates
+ Workaround: Completely reworked mod managers paths and usage(again)
+ Future: Coded an internal login to NCSoft ( for *maybe* a near future )
+ Security: Signed application for windowss trust issues

> To also avoid Strictor triggers i removed the admin flag on app, you have to add run-as admin

Version 3.5
+ Bug Fix: App Window does not properly restore after Client.exe closed 
+ Change the text when Mods folder in mod manager is empty
+ Spinning progress bar not showing in Mod Manager while working
+ Found an alternative method for using the mods in mod manager

> Mod Manager conflicting cross-threading issue fixed

Version 3.4
+ Fixed Bug: Mod & Undo both available in Mod Manager
+ Added Routine to check if game is running or not to restore app
+ Added Donators tab
+ Added ToolTips

> Tooltips available on each button to help understand what they do

Version 3.3
+ Fixed Bug: Conflicting routine for RegionID
+ Reworked: Routines for the checkboxes(unattended & no texture streaming)
+ Fixed Bug: Patch!/Play! button text not changing properly

> Removed Routines when launching game(faster process)

Version 3.2
+ Fixed Bug: Application would hang(tick having too many stages)
+ Fixed Bug: RegionID & LanguageID would share their values
+ Added: Status of settings(showing values before launch)
+ Added: Donation button(for those who appreciate my work) 
+ Reworked the close/minimize buttons at top

> Properly sets RegionID and languageID values.

Version 3.1
+ Fully Redesigned
+ Reworked some routines
+ Tool Draggable
+ Server Usage Detection System
+ Save Last Used Settings

> Fully resonsive design(requires MetroFramework.dll)

Version 3.0
+ Added Splash Screen Changer!
+ Fixed logs appearing double in Mod Manager
+ Reworked the Restore button for config.dat

> Splash screen changer might have bugs, report them right away!

Version 2.7
+ Fixed the focus of the app(always in background)
+ Fixed the statuses in Mod Manager
+ Fixed the No loading screen after an update

> Now properly checks if the backup already exists after an update

Version 2.6
+ Logs in Mod Manager can not be erased.
+ Statuses at bottom of Mod Manager now tells you if your game has modded files or not properly.

> You can still copy the logs

Version 2.5
+ Added Mod Manager

> Added logs to Mod Manager

> Fixed verification of files

> Added settings for json

> Undo/Mod [Rework]

> Added shortcut to Mod Folder

> Added Refresh if mods folder changed

> Beta release for Mod Manager(tested and worked on my computer[NO WARNING WHILE LAUNCHING GAME!])

Version 2.0
+ Killing game process if already running(tool boot crash fix)
+ Grabs path thru registry(installation path)
+ Dialog to find path if path in registry does not exist(installed in another dir)
+ Fixed automatic game language detector(wrong default values fix)

> Added extra logs for more information

Version 1.5
+ Lowered .Net Framework requirements to 3.5 instead of 4.5.2

> For compatibility issues

Version 1.4
+ Fixed Patch!/Play! buttons text
+ Added intergrated version checker!

> You can use the same Download link to download the latest version

Version 1.3
+ Fixed Logs
+ Intergrated config.dat in tool(no longer relies on internet)
+ Tool no longer requires /patch path and config.dat inside of it

> Logs can be paused if you click on it

Version 1.2
+ Added Logs to app

> Tells successes and fails

Version 1.1
+ Patches the config.dat with Miyakos config.dat!
+ Added restore button for config.dat

> Backup kept for restore in /backup/config.dat at the Original config.dats location

Version 1.0
+ Greatly optimized the code compared to BnS-Ark
+ Added Launch! (Start the game)
+ Added Ping (green,orange,red) [red = unplayable | orange = barely playable | green = perfect gameplay]
+ Added Option to select language of game
+ Added Option to select game server based on your country

> No Loading Screen button toggle
